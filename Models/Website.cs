
public class Website
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public ICollection<Metric> Metrics { get; set; } = new List<Metric>();
    public ICollection<Report> Reports { get; set; } = new List<Report>();
}