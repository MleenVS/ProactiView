
using System;
using System.Collections.Generic;

namespace ProactiView.Models
{
    public class Website
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Url { get; set; } = default!;
        public ICollection<Metric> Metrics { get; set; } = new List<Metric>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<WebsiteStatus> WebsiteStatuses { get; set; } = new List<WebsiteStatus>();
    }
}