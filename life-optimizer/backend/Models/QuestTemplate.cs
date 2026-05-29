namespace LifeOptimizer.Backend.Models
{
    public class QuestTemplate
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Stat { get; set; } = string.Empty;
        public string Rarity { get; set; } = "Common";
        public int XpReward { get; set; }
    }
}
