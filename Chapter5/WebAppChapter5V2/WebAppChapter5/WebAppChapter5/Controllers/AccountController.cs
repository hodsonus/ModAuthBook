using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppChapter5.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Signs in a user for the current context by performing the configured OpenId Connect operation
        /// and redirecting to the local application root.
        /// </summary>
        public void SignIn()
        {
            // Send an OpenID Connect sign-in request
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new Microsoft.Owin.Security.AuthenticationProperties
                    {
                        RedirectUri = "/"
                    },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType)
                ;
            }
        }

        /// <summary>
        /// Signs out the currently signed in user by performing the configured OpenId Connect operation and the
        /// configured cookie operation.
        public void SignOut()
        {
            // OpenID Connect middleware will emit a sign out message to Azure AD and the cookie middleware
            // will drop the local app's session cookies.
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType
            );
        }
    }
}