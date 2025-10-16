using System.Collections.Generic;

namespace ProactiView.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
    }
}