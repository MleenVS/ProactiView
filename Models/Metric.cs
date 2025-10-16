
public class Metric
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty; // e.g., "Performance", "Health"
    public double Value { get; set; }
    public DateTime Timestamp { get; set; }
    public int WebsiteId { get; set; }
    public Website Website { get; set; } = null!;
}