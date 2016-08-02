using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Simple.OAuthServer.Models;

namespace Simple.OAuthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new ApplicationDbContext());
            app.CreatePerOwinContext<ApplicationUserManager>(CreateUserManager);

            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            var oauthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/oauth/token"),
                Provider = new AuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true
            };

            app.UseOAuthAuthorizationServer(oauthOptions);
        }

        private static ApplicationUserManager CreateUserManager(IdentityFactoryOptions<ApplicationUserManager> options,
                                                            IOwinContext context)
        {
            var dbContext = context.Get<ApplicationDbContext>();
            var userStore = new ApplicationUserStore(dbContext);
            var userManager = new ApplicationUserManager(userStore);
            
            userManager.UserValidator = new UserValidator<ApplicationIdentityUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                userManager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationIdentityUser>(
                        dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return userManager;
        }
    }
}