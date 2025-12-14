namespace proxy.Models;

public class Payment
{
    public int id { get; set; }

    public int user_id { get; set; }

    public float amount { get; set; }

    public DateTime timestamp { get; set; }
}