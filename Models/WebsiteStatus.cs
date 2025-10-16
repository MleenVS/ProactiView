namespace ProactiView.Models;

public class WebsiteStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public bool IsOnline { get; set; }
    public DateTime LastChecked { get; set; }
}