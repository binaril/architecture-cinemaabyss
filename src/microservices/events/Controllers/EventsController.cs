using events.Models;
using events.Services;
using Microsoft.AspNetCore.Mvc;

namespace events.Controllers;

[ApiController]
public class EventsController(EventsService service) : ControllerBase
{
    [HttpPost("api/events/movie")]
    public async Task<IActionResult> SendMovie([FromBody] MovieEvent data)
    {
        var result = await service.SendMovie(data);
        return StatusCode(201, result);
    }

    [HttpPost("api/events/user")]
    public async Task<IActionResult> SendUser([FromBody] UserEvent data)
    {
        var result = await service.SendUser(data);
        return StatusCode(201, result);
    }

    [HttpPost("api/events/payment")]
    public async Task<IActionResult> SendPayment([FromBody] PaymentEvent data)
    {
        var result = await service.SendPayment(data);
        return StatusCode(201, result);
    }
}