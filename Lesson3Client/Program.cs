using Lesson3Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? "https://lesson3apimanagement.azure-api.net/Lesson3API/v2/") });
builder.Services.AddFileReaderService(options => options.UseWasmSharedBuffer = true);

await builder.Build().RunAsync();