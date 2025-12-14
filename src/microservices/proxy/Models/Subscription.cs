namespace proxy.Models;

public class Subscription
{
    public int id { get; set; }
    public int user_id { get; set; }
    public string plan_type { get; set; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
}