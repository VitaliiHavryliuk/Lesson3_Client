using Lesson3Client;
using Lesson3Client.Auth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient("API_Client", client => client.BaseAddress = new Uri("https://lesson3apimanagement.azure-api.net/Lesson3API/v2/"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API_Client"));

builder.Services.AddFileReaderService(options => options.UseWasmSharedBuffer = true);

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/User.Read");
    options.ProviderOptions.AdditionalScopesToConsent.Add("https://graph.microsoft.com/email");
    options.ProviderOptions.AdditionalScopesToConsent.Add("https://graph.microsoft.com/profile");
    options.ProviderOptions.LoginMode = "redirect";
});

await builder.Build().RunAsync();