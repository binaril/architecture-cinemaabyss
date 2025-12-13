namespace events.Models;

public class UserEvent
{
    public int user_id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string action { get; set; }
    public DateTime timestamp { get; set; }
}