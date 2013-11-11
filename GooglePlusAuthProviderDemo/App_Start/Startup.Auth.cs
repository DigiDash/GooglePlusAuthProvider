using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Owin.Security.GooglePlus;

namespace GooglePlusAuthProviderDemo
{
    public partial class Startup
    {
        public const string GooglePlusClientId = "<YOUR CLIENT ID>";
        public const string GooglePlusClientSecret = "<YOUR CLIENT SECRET>";

        public const string GooglePlusAccessTokenClaimType = "urn:tokens:gooleplus:accesstoken";

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGooglePlusAuthentication(
                new GooglePlusAuthenticationOptions
                {
                    Caption = "Google+",
                    ClientId = GooglePlusClientId,
                    ClientSecret = GooglePlusClientSecret,
                    Provider = new GooglePlusAuthenticationProvider
                    {
                        OnAuthenticated = async context =>
                        {
                            context.Identity.AddClaim(new Claim(GooglePlusAccessTokenClaimType, context.AccessToken));
                        }
                    }
                });
        }
    }
}