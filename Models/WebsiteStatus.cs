// C# ProactiView.Models/WebsiteStatus.cs
using System;

namespace ProactiView.Models
{
    public class WebsiteStatus
    {
        public int Id { get; set; }
        public string Status { get; set; } = default!; // e.g. "Up"/"Down"
        public DateTime CheckedAt { get; set; }
        public int WebsiteId { get; set; }
        public Website? Website { get; set; }
    }
}