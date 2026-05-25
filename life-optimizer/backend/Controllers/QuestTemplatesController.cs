using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Backend.Data;
using LifeOptimizer.Backend.Models;

namespace LifeOptimizer.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestTemplatesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public QuestTemplatesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var quests = await _db.QuestTemplates.OrderBy(q => q.Rarity).ThenBy(q => q.Title).ToListAsync();
            return Ok(quests);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuestTemplateDto newQuest)
        {
            if (string.IsNullOrWhiteSpace(newQuest.Title) || string.IsNullOrWhiteSpace(newQuest.Stat))
            {
                return BadRequest(new { message = "Quest title and stat are required." });
            }

            var template = new QuestTemplate
            {
                Title = newQuest.Title.Trim(),
                Stat = newQuest.Stat.Trim(),
                Rarity = string.IsNullOrWhiteSpace(newQuest.Rarity) ? "Common" : newQuest.Rarity.Trim(),
                XpReward = newQuest.XpReward > 0 ? newQuest.XpReward : 10
            };

            _db.QuestTemplates.Add(template);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = template.Id }, template);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var template = await _db.QuestTemplates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            _db.QuestTemplates.Remove(template);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("normalize")]
        public async Task<IActionResult> NormalizeStats()
        {
            var stats = await _db.Stats.ToListAsync();
            var templates = await _db.QuestTemplates.ToListAsync();
            var changed = new List<object>();

            foreach (var t in templates)
            {
                if (string.IsNullOrWhiteSpace(t.Stat)) continue;

                // exact match
                var exact = stats.FirstOrDefault(s => s.Subject.Equals(t.Stat, StringComparison.OrdinalIgnoreCase));
                if (exact != null && !t.Stat.Equals(exact.Subject, StringComparison.Ordinal))
                {
                    var old = t.Stat;
                    t.Stat = exact.Subject;
                    changed.Add(new { t.Id, oldStat = old, newStat = t.Stat });
                    continue;
                }

                // partial match
                var partial = stats.FirstOrDefault(s => s.Subject.IndexOf(t.Stat, StringComparison.OrdinalIgnoreCase) >= 0
                                                        || t.Stat.IndexOf(s.Subject, StringComparison.OrdinalIgnoreCase) >= 0);
                if (partial != null && !t.Stat.Equals(partial.Subject, StringComparison.Ordinal))
                {
                    var old = t.Stat;
                    t.Stat = partial.Subject;
                    changed.Add(new { t.Id, oldStat = old, newStat = t.Stat });
                    continue;
                }

                // fallback: 4-char prefix fuzzy match
                string Prefix(string x) => x.Length <= 4 ? x : x.Substring(0, 4);
                var pref = stats.FirstOrDefault(s => Prefix(s.Subject).Equals(Prefix(t.Stat), StringComparison.OrdinalIgnoreCase));
                if (pref != null && !t.Stat.Equals(pref.Subject, StringComparison.Ordinal))
                {
                    var old = t.Stat;
                    t.Stat = pref.Subject;
                    changed.Add(new { t.Id, oldStat = old, newStat = t.Stat });
                }
            }

            if (changed.Any())
            {
                await _db.SaveChangesAsync();
            }

            return Ok(new { updated = changed.Count, changes = changed });
        }
    }

    public class CreateQuestTemplateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Stat { get; set; } = string.Empty;
        public string Rarity { get; set; } = "Common";
        public int XpReward { get; set; } = 10;
    }
}
