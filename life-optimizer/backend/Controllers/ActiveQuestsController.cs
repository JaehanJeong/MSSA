using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Backend.Data;
using LifeOptimizer.Backend.Models;

namespace LifeOptimizer.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActiveQuestsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private const int LevelUpThreshold = 100;

        public ActiveQuestsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profile = await _db.Profiles.FirstOrDefaultAsync();
            if (profile == null)
            {
                return NotFound(new { message = "Profile not initialized." });
            }

            var quests = await _db.ActiveQuests
                .Include(a => a.QuestTemplate)
                .Where(a => !a.IsCompleted)
                .OrderByDescending(a => a.AssignedAt)
                .Take(profile.QuestCapacity)
                .ToListAsync();

            var result = quests.Select(a => new
            {
                a.Id,
                a.AssignedAt,
                a.IsCompleted,
                QuestTemplate = new
                {
                    a.QuestTemplate!.Id,
                    a.QuestTemplate.Title,
                    a.QuestTemplate.Stat,
                    a.QuestTemplate.Rarity,
                    a.QuestTemplate.XpReward
                }
            });

            return Ok(result);
        }

        [HttpPost("roll")]
        public async Task<IActionResult> Roll([FromBody] RollRequest request)
        {
            var profile = await _db.Profiles.FirstOrDefaultAsync();
            if (profile == null)
            {
                return NotFound(new { message = "Profile not initialized." });
            }

            var activeTemplateIds = await _db.ActiveQuests
                .Where(a => !a.IsCompleted)
                .Select(a => a.QuestTemplateId)
                .ToListAsync();

            var templates = await _db.QuestTemplates.ToListAsync();
            if (!templates.Any())
            {
                return BadRequest(new { message = "No quest templates available to roll." });
            }

            var availableTemplates = templates.Where(t => !activeTemplateIds.Contains(t.Id)).ToList();
            if (!availableTemplates.Any())
            {
                availableTemplates = templates.ToList();
            }

            var stats = await _db.Stats.ToListAsync();

            // Build per-template weights using best-effort matching between template.Stat and Stat.Subject
            double GetWeightForTemplate(QuestTemplate t)
            {
                if (string.IsNullOrWhiteSpace(t.Stat)) return 0.0;

                // try exact match (case-insensitive)
                var exact = stats.FirstOrDefault(s => s.Subject.Equals(t.Stat, StringComparison.OrdinalIgnoreCase));
                if (exact != null) return Math.Max(exact.Weight, 0.0);

                // try contains / partial matches (stat contains template or template contains stat)
                var partial = stats.FirstOrDefault(s => s.Subject.IndexOf(t.Stat, StringComparison.OrdinalIgnoreCase) >= 0
                                                        || t.Stat.IndexOf(s.Subject, StringComparison.OrdinalIgnoreCase) >= 0);
                if (partial != null) return Math.Max(partial.Weight, 0.0);
                
                     // fallback: 4-char prefix fuzzy match (helps for 'Intelligence' vs 'Intellect')
                     string Prefix(string x) => x.Length <= 4 ? x : x.Substring(0, 4);
                     var pref = stats.FirstOrDefault(s => Prefix(s.Subject).Equals(Prefix(t.Stat), StringComparison.OrdinalIgnoreCase));
                     if (pref != null) return Math.Max(pref.Weight, 0.0);

                // fallback to zero weight
                return 0.0;
            }

            // Only consider templates that map to an existing stat
            var candidates = availableTemplates.Where(t => GetWeightForTemplate(t) > 0).ToList();
            if (!candidates.Any())
            {
                return BadRequest(new { message = "No quest templates match your current attributes. Add or normalize templates to existing stats first." });
            }

            var templateWeights = candidates.ToDictionary(t => t.Id, t => GetWeightForTemplate(t));
            var totalWeight = templateWeights.Values.Sum();

            var requested = request.Count > 0 ? request.Count : profile.QuestCapacity;

            var existingActiveCount = activeTemplateIds.Count;
            var availableSlots = Math.Max(0, profile.QuestCapacity - existingActiveCount);
            var toCreate = Math.Min(requested, availableSlots);

            if (toCreate <= 0)
            {
                return BadRequest(new { message = "No available quest slots. Complete or remove existing quests first." });
            }

            List<QuestTemplate> chosen;
            if (totalWeight <= 0)
            {
                chosen = candidates.OrderBy(_ => Guid.NewGuid()).Take(toCreate).ToList();
            }
            else
            {
                chosen = new List<QuestTemplate>();
                var rollCandidates = candidates.ToList();

                for (var i = 0; i < toCreate && rollCandidates.Any(); i++)
                {
                        var weights = rollCandidates.Select(t => templateWeights.GetValueOrDefault(t.Id, 0.0)).ToList();
                    var currentTotal = weights.Sum();
                    if (currentTotal <= 0)
                    {
                        chosen.AddRange(rollCandidates.OrderBy(_ => Guid.NewGuid()).Take(toCreate - chosen.Count));
                        break;
                    }

                    var pick = Random.Shared.NextDouble() * currentTotal;
                    var cumulative = 0.0;
                    QuestTemplate? selected = null;

                    for (var index = 0; index < rollCandidates.Count; index++)
                    {
                        cumulative += weights[index];
                        if (pick <= cumulative)
                        {
                            selected = rollCandidates[index];
                            break;
                        }
                    }

                    if (selected == null)
                    {
                        selected = rollCandidates.Last();
                    }

                    chosen.Add(selected);
                    rollCandidates.Remove(selected);
                }
            }

            var activeQuests = chosen.Select(template => new ActiveQuest
            {
                QuestTemplateId = template.Id,
                AssignedAt = DateTime.UtcNow
            }).ToList();

            _db.ActiveQuests.AddRange(activeQuests);
            await _db.SaveChangesAsync();
            return Ok(activeQuests.Select(a => new { a.Id, a.QuestTemplateId, a.AssignedAt }));
        }

        [HttpPost("complete")]
        public async Task<IActionResult> Complete([FromBody] CompleteRequest request)
        {
            var activeQuest = await _db.ActiveQuests
                .Include(a => a.QuestTemplate)
                .FirstOrDefaultAsync(a => a.Id == request.ActiveQuestId);

            if (activeQuest == null)
            {
                return NotFound(new { message = "Active quest not found." });
            }

            if (activeQuest.IsCompleted)
            {
                return BadRequest(new { message = "Quest is already completed." });
            }

            activeQuest.IsCompleted = true;
            var quest = activeQuest.QuestTemplate!;

            var stat = await _db.Stats.FirstOrDefaultAsync(s => s.Subject == quest.Stat);
            if (stat != null)
            {
                stat.Level = Math.Min(stat.Level + 1, 100);
            }

            var profile = await _db.Profiles.FirstOrDefaultAsync();
            if (profile == null)
            {
                return NotFound(new { message = "Profile not initialized." });
            }

            profile.GlobalXp += quest.XpReward;
            var levelsGained = 0;
            while (profile.GlobalXp >= LevelUpThreshold)
            {
                profile.GlobalXp -= LevelUpThreshold;
                profile.GlobalLevel += 1;
                levelsGained += 1;
            }

            await _db.SaveChangesAsync();

            return Ok(new
            {
                activeQuest.Id,
                completedQuest = new
                {
                    quest.Id,
                    quest.Title,
                    quest.Stat,
                    quest.Rarity,
                    quest.XpReward
                },
                profile.GlobalXp,
                profile.GlobalLevel,
                levelsGained
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var activeQuest = await _db.ActiveQuests.FirstOrDefaultAsync(a => a.Id == id);
            if (activeQuest == null)
            {
                return NotFound(new { message = "Active quest not found." });
            }

            _db.ActiveQuests.Remove(activeQuest);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Deleted." });
        }

        [HttpPost("reroll")]
        public async Task<IActionResult> Reroll([FromBody] RerollRequest request)
        {
            var activeQuest = await _db.ActiveQuests.FirstOrDefaultAsync(a => a.Id == request.ActiveQuestId);
            if (activeQuest == null)
            {
                return NotFound(new { message = "Active quest not found." });
            }

            var templates = await _db.QuestTemplates.ToListAsync();
            if (!templates.Any()) return BadRequest(new { message = "No quest templates available to reroll." });

            var available = templates.Where(t => t.Id != activeQuest.QuestTemplateId).ToList();
            if (!available.Any()) return BadRequest(new { message = "No alternative templates available to reroll." });

            var newTemplate = available.OrderBy(_ => Guid.NewGuid()).First();

            activeQuest.QuestTemplateId = newTemplate.Id;
            activeQuest.AssignedAt = DateTime.UtcNow;
            activeQuest.IsCompleted = false;

            await _db.SaveChangesAsync();

            return Ok(new
            {
                activeQuest.Id,
                activeQuest.AssignedAt,
                QuestTemplate = new
                {
                    newTemplate.Id,
                    newTemplate.Title,
                    newTemplate.Stat,
                    newTemplate.Rarity,
                    newTemplate.XpReward
                }
            });
        }
    }

    public class RollRequest
    {
        public int Count { get; set; }
    }

    public class CompleteRequest
    {
        public int ActiveQuestId { get; set; }
    }

    public class RerollRequest
    {
        public int ActiveQuestId { get; set; }
    }
}
