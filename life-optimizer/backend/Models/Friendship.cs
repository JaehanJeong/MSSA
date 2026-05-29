namespace LifeOptimizer.Backend.Models
{
    public class Friendship
    {
        public int Id { get; set; }
        public int UserId { get; set; }      // requester
        public int FriendId { get; set; }    // receiver
        public string Status { get; set; } = "Pending";  // "Pending" | "Accepted"
        public DateTime? AcceptedAt { get; set; }
    }
}
