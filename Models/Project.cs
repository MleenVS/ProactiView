using System.Collections.Generic;

namespace ProactiView.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    }
}