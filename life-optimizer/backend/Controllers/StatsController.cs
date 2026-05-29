using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Backend.Data;
using LifeOptimizer.Backend.Models;

namespace LifeOptimizer.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StatsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromHeader(Name = "X-User-Id")] int userId = 0)
        {
            var stats = await (userId > 0
                ? _db.Stats.Where(s => s.UserId == userId)
                : _db.Stats.Where(s => s.UserId == null))
                .OrderBy(s => s.Subject)
                .ToListAsync();
            return Ok(stats);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStatDto request, [FromHeader(Name = "X-User-Id")] int userId = 0)
        {
            if (string.IsNullOrWhiteSpace(request.Subject))
            {
                return BadRequest(new { message = "Stat subject is required." });
            }

            var stat = new Stat
            {
                UserId = userId > 0 ? userId : null,
                Subject = request.Subject.Trim(),
                Level = request.Level > 0 ? request.Level : 0,
                Weight = request.Weight > 0 ? request.Weight : 1.0
            };

            _db.Stats.Add(stat);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = stat.Id }, stat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromHeader(Name = "X-User-Id")] int userId = 0)
        {
            var stat = userId > 0
                ? await _db.Stats.FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId)
                : await _db.Stats.FirstOrDefaultAsync(s => s.Id == id && s.UserId == null);

            if (stat == null)
            {
                return NotFound();
            }

            var templates = await _db.QuestTemplates
                .Where(t => t.Stat == stat.Subject && (userId > 0 ? t.UserId == userId : t.UserId == null))
                .ToListAsync();

            if (templates.Count > 0)
            {
                var templateIds = templates.Select(t => t.Id).ToList();
                var activeQuests = await _db.ActiveQuests
                    .Where(a => templateIds.Contains(a.QuestTemplateId))
                    .ToListAsync();
                _db.ActiveQuests.RemoveRange(activeQuests);
                _db.QuestTemplates.RemoveRange(templates);
            }

            _db.Stats.Remove(stat);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }

    public class CreateStatDto
    {
        public string Subject { get; set; } = string.Empty;
        public int Level { get; set; } = 10;
        public double Weight { get; set; } = 1.0;
    }
}
