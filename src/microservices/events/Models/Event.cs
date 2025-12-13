namespace events.Models;

public class Event<T>
{
    public string id { get; set; }

    public string type { get; set; }

    public DateTime timestamp { get; set; }

    public T payload { get; set; }
}