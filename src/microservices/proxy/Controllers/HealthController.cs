using Microsoft.AspNetCore.Mvc;
using proxy.Models;
using proxy.Services;

namespace proxy.Controllers;

[ApiController]
public class HealthController(HealthGatewayService gatewayService): ControllerBase
{

    [HttpGet("api/movies/health")]
    public async Task<HealthStatus> ChechMovies()
    {
        return await gatewayService.CheckMovies();
    }

    [HttpGet("api/events/health")]
    public async Task<HealthStatus> CreateUsers()
    {
        return await gatewayService.CheckEvents();
    }
        
}