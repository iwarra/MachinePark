using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MachinePark.Client.Pages;

namespace MachinePark.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            // Add HTTP client service for API calls
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7207/") });

            // Build and run the app
            await builder.Build().RunAsync();
        }
    }
}
