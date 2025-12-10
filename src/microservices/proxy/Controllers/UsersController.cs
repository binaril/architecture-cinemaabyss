using Microsoft.AspNetCore.Mvc;
using proxy.Models;
using proxy.Services;

namespace proxy.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(UsersGatewayService gatewayService): ControllerBase
{

    [HttpGet]
    public async Task<List<User>> GetUsers()
    {
        return await gatewayService.Get();
    }

    [HttpPost]
    public async Task<User> CreateUser([FromBody] UserInput user)
    {
        return await gatewayService.Create(user);
    }
        
}