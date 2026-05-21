namespace LifeOptimizer.Backend.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public int Level { get; set; }
        public double Weight { get; set; }
    }
}
