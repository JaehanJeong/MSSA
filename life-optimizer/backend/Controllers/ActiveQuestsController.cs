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
            var quests = await _db.ActiveQuests
                .Include(a => a.QuestTemplate)
                .Where(a => !a.IsCompleted)
                .OrderByDescending(a => a.AssignedAt)
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

            var templates = await _db.QuestTemplates.ToListAsync();
            if (!templates.Any())
            {
                return BadRequest(new { message = "No quest templates available to roll." });
            }

            var count = request.Count > 0 ? request.Count : profile.QuestCapacity;
            var chosen = templates.OrderBy(_ => Guid.NewGuid()).Take(count).ToList();

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
    }

    public class RollRequest
    {
        public int Count { get; set; }
    }

    public class CompleteRequest
    {
        public int ActiveQuestId { get; set; }
    }
}
