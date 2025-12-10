using Microsoft.AspNetCore.Mvc;
using proxy.Models;
using proxy.Services;

namespace proxy.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController(MovieGatewayService gatewayService): ControllerBase
{
    [HttpGet]
    public async Task<List<Movie>> Get()
    {
        return await gatewayService.Get();
    }

    [HttpPost]
    public async Task<Movie> Create([FromBody] MovieInput user)
    {
        return await gatewayService.Create(user);
    }
    
}