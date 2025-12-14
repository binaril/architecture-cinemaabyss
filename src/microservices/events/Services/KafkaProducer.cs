using System.Text.Json;
using Confluent.Kafka;
using events.Models;

namespace events.Services;

public class KafkaProducer
{
    private readonly IProducer<Null, string> _producer;
    
    public KafkaProducer()
    {
        var config = new ProducerConfig { BootstrapServers = Environment.GetEnvironmentVariable("KAFKA_BROKERS"), ClientId = "cinema-events-producer" };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }
    
    public async Task<KafkaResult> Produce<T>(string topic, Event<T> data)
    {
        var message = new Message<Null, string> { Value = JsonSerializer.Serialize(data) };
        var deliveryReport = await _producer.ProduceAsync(topic, message);

        return new KafkaResult
        {
            offset = deliveryReport.Offset.Value,
            partition = deliveryReport.Partition.Value,
            isSucces = deliveryReport.Status == PersistenceStatus.Persisted,
        };
    }
}