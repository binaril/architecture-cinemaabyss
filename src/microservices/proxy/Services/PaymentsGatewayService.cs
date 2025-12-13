using System.Text.Json;
using proxy.Models;

namespace proxy.Services;

public class PaymentsGatewayService(IHttpClientFactory factory)
{
    public async Task<List<Payment>> Get(int userId)
    {
        var client = factory.CreateClient();

        return await client.GetFromJsonAsync<List<Payment>>(
            $"{Environment.GetEnvironmentVariable("MONOLITH_URL")}/api/payments?userId={userId}",
            new JsonSerializerOptions(JsonSerializerDefaults.Web)) ?? [];
    }

    public async Task<Payment> Create(PaymentInput user)
    {
        var client = factory.CreateClient();

        var result = await client.PostAsJsonAsync(
            $"{Environment.GetEnvironmentVariable("MONOLITH_URL")}/api/users",
            user);

        var content = await result.Content.ReadAsStringAsync();

        if (!result.IsSuccessStatusCode) throw new Exception($"Error creating user: {content}");

        return await result.Content.ReadFromJsonAsync<Payment>(
                   new JsonSerializerOptions(JsonSerializerDefaults.Web))
               ?? throw new Exception("Error");
    }
}