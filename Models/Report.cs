// C# ProactiView.Models/Report.cs
using System;

namespace ProactiView.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime Created { get; set; }
        public int WebsiteId { get; set; }
        public Website? Website { get; set; }
    }
}