using proxy.Models;

namespace proxy.Services;

public class HealthGatewayService(IHttpClientFactory factory)
{
    public async Task<HealthStatus> CheckMovies()
    {
        var client = factory.CreateClient();
        
        var result = await client.GetAsync(
            $"{Environment.GetEnvironmentVariable("MOVIES_SERVICE_URL")}/health");

        return new HealthStatus
        {
            status = result.IsSuccessStatusCode
        };
    }
    
    public async Task<HealthStatus> CheckEvents()
    {
        var client = factory.CreateClient();
        
        var result = await client.GetAsync(
            $"{Environment.GetEnvironmentVariable("EVENTS_SERVICE_URL")}/health");

        return new HealthStatus
        {
            status = result.IsSuccessStatusCode
        };
    }
    
    
}