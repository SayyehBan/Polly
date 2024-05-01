using Polly.Extensions.Http;
using Polly;

namespace ClientApi.Polly;

public class PollyConfig
{
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
            .WaitAndRetryAsync(new[]
            {
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5),
            }, (_, waitingTime) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Polly retry policy {DateTime.Now.ToLongTimeString()}");
                Console.ResetColor();
            });
    }

    public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));
    }
}
