namespace LifeOptimizer.Backend.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int GlobalXp { get; set; }
        public int GlobalLevel { get; set; }
        public int QuestCapacity { get; set; }
    }
}
