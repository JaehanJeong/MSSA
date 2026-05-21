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
        public async Task<IActionResult> Get()
        {
            var stats = await _db.Stats.OrderBy(s => s.Subject).ToListAsync();
            return Ok(stats);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStatDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Subject))
            {
                return BadRequest(new { message = "Stat subject is required." });
            }

            var stat = new Stat
            {
                Subject = request.Subject.Trim(),
                Level = request.Level > 0 ? request.Level : 10,
                Weight = request.Weight > 0 ? request.Weight : 1.0
            };

            _db.Stats.Add(stat);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = stat.Id }, stat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stat = await _db.Stats.FindAsync(id);
            if (stat == null)
            {
                return NotFound();
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
