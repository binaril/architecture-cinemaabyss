using System.Text.Json;
using proxy.Helper;
using proxy.Models;

namespace proxy.Services;

public class MovieGatewayService(IHttpClientFactory factory)
{
    public async Task<List<Movie>> Get()
    {
        var client = factory.CreateClient();

        return await client.GetFromJsonAsync<List<Movie>>(
            $"{ServiceUrlHelper.GetService("MOVIES_SERVICE_URL")}/api/movies",
            new JsonSerializerOptions(JsonSerializerDefaults.Web)) ?? [];
    }

    public async Task<Movie> Create(MovieInput user)
    {
        var client = factory.CreateClient();

        var result = await client.PostAsJsonAsync(
            $"{ServiceUrlHelper.GetService("MOVIES_SERVICE_URL")}/api/movies",
            user);

        var content = await result.Content.ReadAsStringAsync();

        if (!result.IsSuccessStatusCode) throw new Exception($"Error creating user: {content}");

        return await result.Content.ReadFromJsonAsync<Movie>(
                   new JsonSerializerOptions(JsonSerializerDefaults.Web))
               ?? throw new Exception("Error");
    }
}