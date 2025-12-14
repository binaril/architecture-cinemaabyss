using events.Services;

namespace events.Consumers;

public class MoviesConsumer(ILogger<MoviesConsumer> logger, ConsumerSourceService consumerSource): BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var consumer = consumerSource.GetConsumer();
            
        consumer.Subscribe("movie-events");
        
        while (!stoppingToken.IsCancellationRequested) { var result = consumer.Consume(stoppingToken); 
            logger.LogWarning("Received message: {MessageValue}", result.Message.Value); }

        return Task.CompletedTask;
    }
}