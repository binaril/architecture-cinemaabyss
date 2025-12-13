using events.Models;

namespace events.Services;

public class EventsService(KafkaProducer kafkaProducer)
{
    public async Task<EventResponse<MovieEvent>> SendMovie(MovieEvent data)
    {
        var eventObject = new Event<MovieEvent>
        {
            id = Guid.NewGuid().ToString(),
            type = "movie",
            timestamp = DateTime.UtcNow,
            payload = data
        };
        
        var result = await kafkaProducer.Produce("movie-events", eventObject);
        if (!result.isSucces) throw new Exception("event not sent");
        
        return new EventResponse<MovieEvent>
        {
            status = "success",
            partition = result.partition,
            offset = result.offset,
            eventObject = eventObject
        };
    }

    public async Task<EventResponse<UserEvent>> SendUser(UserEvent data)
    {
        var eventObject = new Event<UserEvent>
        {
            id = Guid.NewGuid().ToString(),
            type = "user",
            timestamp = DateTime.UtcNow,
            payload = data
        };
        
        var result = await kafkaProducer.Produce("user-events", eventObject);
        if (!result.isSucces) throw new Exception("event not sent");
        
        return new EventResponse<UserEvent>
        {
            status = "success",
            partition = result.partition,
            offset = result.offset,
            eventObject = eventObject
        };
    }

    public async Task<EventResponse<PaymentEvent>> SendPayment(PaymentEvent data)
    {
        var eventObject = new Event<PaymentEvent>
        {
            id = Guid.NewGuid().ToString(),
            type = "payment",
            timestamp = DateTime.UtcNow,
            payload = data
        };
        
        var result = await kafkaProducer.Produce("payment-events", eventObject);
        if (!result.isSucces) throw new Exception("event not sent");
        
        return new EventResponse<PaymentEvent>
        {
            status = "success",
            partition = result.partition,
            offset = result.offset,
            eventObject = eventObject
        };
    }
}