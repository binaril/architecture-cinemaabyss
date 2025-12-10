using Microsoft.AspNetCore.Mvc;
using proxy.Models;
using proxy.Services;

namespace proxy.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController(PaymentsGatewayService gatewayService): ControllerBase
{
    [HttpGet]
    public async Task<List<Payment>> Get([FromQuery] int user_id)
    {
        return await gatewayService.Get(user_id);
    }

    [HttpPost]
    public async Task<Payment> Create([FromBody] PaymentInput user)
    {
        return await gatewayService.Create(user);
    }
    
}