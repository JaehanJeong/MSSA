using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Backend.Data;
using LifeOptimizer.Backend.Models;

namespace LifeOptimizer.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InboxController : ControllerBase
    {
        private readonly AppDbContext _db;

        public InboxController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetInbox([FromHeader(Name = "X-User-Id")] int userId)
        {
            var items = await _db.SharedQuests
                .Where(s => s.ReceiverId == userId)
                .OrderByDescending(s => s.SentAt)
                .ToListAsync();

            return Ok(items);
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] SendQuestDto dto, [FromHeader(Name = "X-User-Id")] int userId)
        {
            var sender = await _db.Users.FindAsync(userId);
            if (sender == null) return Unauthorized();

            var recipient = await _db.Users.FirstOrDefaultAsync(u => u.Username == dto.RecipientUsername);
            if (recipient == null)
                return NotFound(new { message = $"User '{dto.RecipientUsername}' not found." });

            var shared = new SharedQuest
            {
                SenderId = userId,
                SenderUsername = sender.Username,
                ReceiverId = recipient.Id,
                Title = dto.Title,
                Stat = dto.Stat,
                Rarity = dto.Rarity,
                XpReward = dto.XpReward,
            };

            _db.SharedQuests.Add(shared);
            await _db.SaveChangesAsync();

            return Ok(new { message = $"Quest shared with {recipient.Username}." });
        }

        [HttpPost("{id}/read")]
        public async Task<IActionResult> MarkRead(int id, [FromHeader(Name = "X-User-Id")] int userId)
        {
            var item = await _db.SharedQuests.FirstOrDefaultAsync(s => s.Id == id && s.ReceiverId == userId);
            if (item == null) return NotFound();

            item.IsRead = true;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/add-to-library")]
        public async Task<IActionResult> AddToLibrary(int id, [FromHeader(Name = "X-User-Id")] int userId)
        {
            var item = await _db.SharedQuests.FirstOrDefaultAsync(s => s.Id == id && s.ReceiverId == userId);
            if (item == null) return NotFound();

            var template = new QuestTemplate
            {
                UserId = userId,
                Title = item.Title,
                Stat = item.Stat,
                Rarity = item.Rarity,
                XpReward = item.XpReward,
            };

            _db.QuestTemplates.Add(template);
            item.IsRead = true;
            await _db.SaveChangesAsync();

            return Ok(template);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromHeader(Name = "X-User-Id")] int userId)
        {
            var item = await _db.SharedQuests.FirstOrDefaultAsync(s => s.Id == id && s.ReceiverId == userId);
            if (item == null) return NotFound();

            _db.SharedQuests.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }

    public class SendQuestDto
    {
        public string RecipientUsername { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Stat { get; set; } = string.Empty;
        public string Rarity { get; set; } = string.Empty;
        public int XpReward { get; set; }
    }
}
