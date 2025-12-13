using System.Text.Json;
using proxy.Models;

namespace proxy.Services;

public class SubscriptionsGatewayService(IHttpClientFactory factory)
{
    public async Task<List<Subscription>> Get(int userId)
    {
        var client = factory.CreateClient();

        return await client.GetFromJsonAsync<List<Subscription>>(
            $"{Environment.GetEnvironmentVariable("MONOLITH_URL")}/api/subscriptions?userId={userId}",
            new JsonSerializerOptions(JsonSerializerDefaults.Web)) ?? [];
    }

    public async Task<Subscription> Create(SubscriptionInput user)
    {
        var client = factory.CreateClient();

        var result = await client.PostAsJsonAsync(
            $"{Environment.GetEnvironmentVariable("MONOLITH_URL")}/api/subscriptions",
            user);

        var content = await result.Content.ReadAsStringAsync();

        if (!result.IsSuccessStatusCode) throw new Exception($"Error creating subscription: {content}");

        return await result.Content.ReadFromJsonAsync<Subscription>(
                   new JsonSerializerOptions(JsonSerializerDefaults.Web))
               ?? throw new Exception("Error");
    }
}