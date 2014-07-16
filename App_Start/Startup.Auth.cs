using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace MircheeMusic
{
    public partial class Startup
    {
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

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            app.UseFacebookAuthentication(
               appId: "964482664522-bb9lml4drve08f9f9dmfh5ooapfiuehf.apps.googleusercontent.com",
               appSecret: "PcN3vVhjzLQRimwGU4b4CGV4");

            app.UseGoogleAuthentication();
            //app, "964482664522-bb9lml4drve08f9f9dmfh5ooapfiuehf.apps.googleusercontent.com", "PcN3vVhjzLQRimwGU4b4CGV4");

        }

        //public static IAppBuilder UseGoogleAuthentication(
        //   this IAppBuilder app,
        //   string clientId,
        //   string clientSecret)
        //{
        //    return UseGoogleAuthentication(
        //            app,
        //            new GoogleOAuth2AuthenticationOptions
        //            {
        //                ClientId = clientId,
        //                ClientSecret = clientSecret
        //            }
        //        );
        //}
    }
}
