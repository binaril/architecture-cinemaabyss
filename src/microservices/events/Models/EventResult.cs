using System.Text.Json.Serialization;

namespace events.Models;

public class EventResponse<T>
{
    public string status { get; set; }
    public int partition { get; set; }
    public long offset { get; set; }

    [JsonPropertyName("event")] public Event<T> eventObject { get; set; }
}