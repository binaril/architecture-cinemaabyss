namespace events.Models;

public class KafkaResult
{
    public bool isSucces { get; set; }
    public int partition { get; set; }
    public long offset { get; set; }
}