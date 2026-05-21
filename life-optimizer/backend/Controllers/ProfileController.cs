using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Backend.Data;
using LifeOptimizer.Backend.Models;

namespace LifeOptimizer.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProfileController(AppDbContext db)
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

            var stats = await _db.Stats.OrderBy(s => s.Subject).ToListAsync();
            return Ok(new
            {
                profile.GlobalXp,
                profile.GlobalLevel,
                profile.QuestCapacity,
                stats
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProfileUpdateDto update)
        {
            var profile = await _db.Profiles.FirstOrDefaultAsync();
            if (profile == null)
            {
                return NotFound(new { message = "Profile not initialized." });
            }

            if (update.QuestCapacity > 0)
            {
                profile.QuestCapacity = update.QuestCapacity;
            }

            if (update.Stats is not null)
            {
                foreach (var statUpdate in update.Stats)
                {
                    var stat = await _db.Stats.FirstOrDefaultAsync(s => s.Id == statUpdate.Id);
                    if (stat is null)
                    {
                        continue;
                    }

                    stat.Level = Math.Clamp(statUpdate.Level, 0, 100);
                    stat.Weight = Math.Max(0.1, statUpdate.Weight);
                }
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }
    }

    public class ProfileUpdateDto
    {
        public int QuestCapacity { get; set; }
        public List<StatUpdateDto>? Stats { get; set; }
    }

    public class StatUpdateDto
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public double Weight { get; set; }
    }
}
