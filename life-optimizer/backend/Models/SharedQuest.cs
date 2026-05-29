namespace LifeOptimizer.Backend.Models
{
    public class SharedQuest
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SenderUsername { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Stat { get; set; } = string.Empty;
        public string Rarity { get; set; } = string.Empty;
        public int XpReward { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
    }
}
