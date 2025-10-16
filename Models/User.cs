using System.Collections.Generic;

namespace ProactiView.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    }
    
}