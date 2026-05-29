using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Backend.Data;
using LifeOptimizer.Backend.Models;

namespace LifeOptimizer.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public FriendsController(AppDbContext db)
        {
            _db = db;
        }

        // Accepted friends with the date the friendship was established
        [HttpGet]
        public async Task<IActionResult> GetFriends([FromHeader(Name = "X-User-Id")] int userId)
        {
            var rows = await _db.Friendships
                .Where(f => f.UserId == userId && f.Status == "Accepted")
                .ToListAsync();

            var friendIds = rows.Select(f => f.FriendId).ToList();
            var users = await _db.Users
                .Where(u => friendIds.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id);

            var result = rows
                .Where(r => users.ContainsKey(r.FriendId))
                .Select(r => new {
                    id = r.FriendId,
                    username = users[r.FriendId].Username,
                    friendshipId = r.Id,
                    addedAt = r.AcceptedAt
                });

            return Ok(result);
        }

        // Pending incoming requests (sent TO the current user)
        [HttpGet("requests")]
        public async Task<IActionResult> GetRequests([FromHeader(Name = "X-User-Id")] int userId)
        {
            var rows = await _db.Friendships
                .Where(f => f.FriendId == userId && f.Status == "Pending")
                .ToListAsync();

            var senderIds = rows.Select(r => r.UserId).ToList();
            var senders = await _db.Users
                .Where(u => senderIds.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id);

            var result = rows
                .Where(r => senders.ContainsKey(r.UserId))
                .Select(r => new {
                    id = r.Id,
                    fromUserId = r.UserId,
                    fromUsername = senders[r.UserId].Username
                });

            return Ok(result);
        }

        // Send a friend request
        [HttpPost("{username}")]
        public async Task<IActionResult> SendRequest(string username, [FromHeader(Name = "X-User-Id")] int userId)
        {
            var target = await _db.Users.FirstOrDefaultAsync(u => u.Username == username.ToLower());
            if (target == null)
                return NotFound(new { message = $"User '{username}' not found." });

            if (target.Id == userId)
                return BadRequest(new { message = "You cannot add yourself." });

            var existing = await _db.Friendships.AnyAsync(f =>
                (f.UserId == userId && f.FriendId == target.Id) ||
                (f.UserId == target.Id && f.FriendId == userId));

            if (existing)
                return Conflict(new { message = "Friend request already sent or already friends." });

            _db.Friendships.Add(new Friendship
            {
                UserId = userId,
                FriendId = target.Id,
                Status = "Pending"
            });
            await _db.SaveChangesAsync();

            return Ok(new { message = $"Friend request sent to {target.Username}." });
        }

        // Accept a pending request
        [HttpPost("{id}/accept")]
        public async Task<IActionResult> AcceptRequest(int id, [FromHeader(Name = "X-User-Id")] int userId)
        {
            var request = await _db.Friendships.FirstOrDefaultAsync(
                f => f.Id == id && f.FriendId == userId && f.Status == "Pending");

            if (request == null) return NotFound();

            var now = DateTime.UtcNow;
            request.Status = "Accepted";
            request.AcceptedAt = now;

            // Create the reverse record so both sides see each other as friends
            _db.Friendships.Add(new Friendship
            {
                UserId = userId,
                FriendId = request.UserId,
                Status = "Accepted",
                AcceptedAt = now
            });

            await _db.SaveChangesAsync();

            var requester = await _db.Users.FindAsync(request.UserId);
            return Ok(new { id = requester!.Id, username = requester.Username, addedAt = now });
        }

        // Reject a pending request
        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectRequest(int id, [FromHeader(Name = "X-User-Id")] int userId)
        {
            var request = await _db.Friendships.FirstOrDefaultAsync(
                f => f.Id == id && f.FriendId == userId && f.Status == "Pending");

            if (request == null) return NotFound();

            _db.Friendships.Remove(request);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Remove an existing friend
        [HttpDelete("{friendId}")]
        public async Task<IActionResult> RemoveFriend(int friendId, [FromHeader(Name = "X-User-Id")] int userId)
        {
            var rows = await _db.Friendships
                .Where(f => (f.UserId == userId && f.FriendId == friendId) ||
                            (f.UserId == friendId && f.FriendId == userId))
                .ToListAsync();

            if (!rows.Any()) return NotFound();

            _db.Friendships.RemoveRange(rows);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
