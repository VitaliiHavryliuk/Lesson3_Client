using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Lesson3Client.Auth
{
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager,
            IConfiguration configuration)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] {"https://lesson3apimanagement.azure-api.net/Lesson3API/v2/" },
                scopes: new[] { "api://66d3c2fa-21f9-46e1-9f5c-11327099cd47/API.Access" });
        }
    }
}
