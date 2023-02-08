using Lesson3Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var prefix = Environment.GetEnvironmentVariable("API_Prefix");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(prefix ?? builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();