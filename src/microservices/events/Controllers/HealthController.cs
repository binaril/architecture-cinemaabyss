using events.Models;
using Microsoft.AspNetCore.Mvc;

namespace events.Controllers;

[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet("api/events/health")]
    public Task<HealthStatus> CreateUsers()
    {
        return Task.FromResult(new HealthStatus
        {
            status = true
        });
    }
}