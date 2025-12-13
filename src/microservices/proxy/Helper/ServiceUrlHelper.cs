namespace proxy.Helper;

public class ServiceUrlHelper
{
    public static string GetService(string serviceName)
    {
        var currentService = CheckIsMicroservice() ? serviceName : "MONOLITH_URL";

        return Environment.GetEnvironmentVariable(currentService) ?? throw new Exception("Microservice not found");
    }

    public static string GetMicroService(string serviceName)
    {
        return Environment.GetEnvironmentVariable(serviceName) ?? throw new Exception("Microservice not found");
    }

    private static bool CheckIsMicroservice()
    {
        var flag = Environment.GetEnvironmentVariable("GRADUAL_MIGRATION") == "true";
        var percentStr = Environment.GetEnvironmentVariable("MOVIES_MIGRATION_PERCENT");
        var percent = int.TryParse(percentStr, out var result) ? result : 0;

        if (!flag || percent <= 0) return false;

        if (percent >= 100) return true;

        var random = new Random(DateTime.Now.Millisecond);

        return random.Next(0, 100) < percent;
    }
}