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
                scopes: new[] { "api://23e403d5-2302-4b2b-8e61-04464b990ff3/API.Access" });
        }
    }
}
