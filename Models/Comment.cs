using System;

namespace ProactiView.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = default!;
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public int? TaskItemId { get; set; }
        public TaskItem? TaskItem { get; set; }
    }
}