using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace WebAppChapter5
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = "a9f162ce-4995-4267-a4d4-a06301b85d3a",
                    Authority = "https://login.microsoftonline.com/hodsonusgmail.onmicrosoft.com",
                    PostLogoutRedirectUri = "https://localhost:44303/"
                }
            );
        }
    }
}