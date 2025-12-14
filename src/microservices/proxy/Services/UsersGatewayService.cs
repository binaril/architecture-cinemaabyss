using System.Text.Json;
using proxy.Models;

namespace proxy.Services;

public class UsersGatewayService(IHttpClientFactory factory)
{
    public async Task<List<User>> Get()
    {
        var client = factory.CreateClient();

        return await client.GetFromJsonAsync<List<User>>(
            $"{Environment.GetEnvironmentVariable("MONOLITH_URL")}/api/users",
            new JsonSerializerOptions(JsonSerializerDefaults.Web)) ?? [];
    }

    public async Task<User> Create(UserInput user)
    {
        var client = factory.CreateClient();

        var userResult = await client.PostAsJsonAsync(
            $"{Environment.GetEnvironmentVariable("MONOLITH_URL")}/api/users",
            user);

        var content = await userResult.Content.ReadAsStringAsync();

        if (!userResult.IsSuccessStatusCode) throw new Exception($"Error creating user: {content}");

        return await userResult.Content.ReadFromJsonAsync<User>(
                   new JsonSerializerOptions(JsonSerializerDefaults.Web))
               ?? throw new Exception("Error");
    }
}