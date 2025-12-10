namespace proxy.Models;

public class MovieInput
{
    public string title { get; set; }
    public string description { get; set; }
    public List<string> genres { get; set; }
    public float rating { get; set; }
}