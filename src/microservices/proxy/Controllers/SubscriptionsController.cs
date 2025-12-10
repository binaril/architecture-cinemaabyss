using Microsoft.AspNetCore.Mvc;
using proxy.Models;
using proxy.Services;

namespace proxy.Controllers;

[ApiController]
[Route("api/subscriptions")]
public class SubscriptionsController(SubscriptionsGatewayService gatewayService): ControllerBase
{
    [HttpGet]
    public async Task<List<Subscription>> Get([FromQuery] int user_id)
    {
        return await gatewayService.Get(user_id);
    }

    [HttpPost]
    public async Task<Subscription> Create([FromBody] SubscriptionInput user)
    {
        return await gatewayService.Create(user);
    }
    
}