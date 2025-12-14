using Confluent.Kafka;

namespace events.Services;

public class ConsumerSourceService
{
    public IConsumer<Ignore, string> GetConsumer()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = Environment.GetEnvironmentVariable("KAFKA_BROKERS"), GroupId = "cinema-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        return new ConsumerBuilder<Ignore, string>(config).Build();
    }
}