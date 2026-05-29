using System;

namespace LifeOptimizer.Backend.Models
{
    public class ActiveQuest
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int QuestTemplateId { get; set; }
        public QuestTemplate? QuestTemplate { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; }
    }
}
