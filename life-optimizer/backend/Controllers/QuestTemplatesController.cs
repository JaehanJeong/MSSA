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
    }

    public class CreateQuestTemplateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Stat { get; set; } = string.Empty;
        public string Rarity { get; set; } = "Common";
        public int XpReward { get; set; } = 10;
    }
}
