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
        public async Task<IActionResult> Get([FromHeader(Name = "X-User-Id")] int userId = 0)
        {
            var profile = await GetOrCreateProfile(userId);

            var stats = await (userId > 0
                ? _db.Stats.Where(s => s.UserId == userId)
                : _db.Stats.Where(s => s.UserId == null))
                .OrderBy(s => s.Subject)
                .ToListAsync();

            return Ok(new
            {
                profile.GlobalXp,
                profile.GlobalLevel,
                profile.QuestCapacity,
                stats
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProfileUpdateDto update, [FromHeader(Name = "X-User-Id")] int userId = 0)
        {
            var profile = await GetOrCreateProfile(userId);

            if (update.QuestCapacity > 0)
                profile.QuestCapacity = update.QuestCapacity;

            if (update.GlobalLevel > 0)
            {
                profile.GlobalLevel = Math.Max(1, update.GlobalLevel);
                profile.GlobalXp = update.GlobalXp;
            }

            if (update.Stats is not null)
            {
                foreach (var statUpdate in update.Stats)
                {
                    var stat = userId > 0
                        ? await _db.Stats.FirstOrDefaultAsync(s => s.Id == statUpdate.Id && s.UserId == userId)
                        : await _db.Stats.FirstOrDefaultAsync(s => s.Id == statUpdate.Id && s.UserId == null);
                    if (stat is null) continue;
                    stat.Level = Math.Clamp(statUpdate.Level, 0, 100);
                    stat.Weight = Math.Max(0, statUpdate.Weight);
                }
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }

        private async Task<Profile> GetOrCreateProfile(int userId)
        {
            var profile = userId > 0
                ? await _db.Profiles.FirstOrDefaultAsync(p => p.UserId == userId)
                : await _db.Profiles.FirstOrDefaultAsync(p => p.UserId == null);

            if (profile is null)
            {
                profile = new Profile
                {
                    UserId = userId > 0 ? userId : null,
                    GlobalXp = 0,
                    GlobalLevel = 1,
                    QuestCapacity = 3
                };
                _db.Profiles.Add(profile);
                await _db.SaveChangesAsync();
            }

            return profile;
        }
    }

    public class ProfileUpdateDto
    {
        public int QuestCapacity { get; set; }
        public int GlobalLevel { get; set; }
        public int GlobalXp { get; set; }
        public List<StatUpdateDto>? Stats { get; set; }
    }

    public class StatUpdateDto
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public double Weight { get; set; }
    }
}
