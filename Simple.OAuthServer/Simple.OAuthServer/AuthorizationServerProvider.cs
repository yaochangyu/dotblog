using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Simple.OAuthServer.Models;

namespace Simple.OAuthServer
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                {"userName", userName}
            };
            return new AuthenticationProperties(data);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
         
            var user = await userManager.FindByNameAsync(context.UserName);
            if (user == null)
            {
                var message = "Invalid credentials. Please try again.";
                context.SetError("invalid_grant", message);
                //context.Rejected();
                return;
            }

            var validCredentials = await userManager.FindAsync(context.UserName, context.Password);
            var enableLockout = await userManager.GetLockoutEnabledAsync(user.Id);

            if (await userManager.IsLockedOutAsync(user.Id))
            {
                var message = string.Format(
                    "Your account has been locked out for {0} minutes due to multiple failed login attempts.",
                    AppSetting.DefaultAccountLockoutTimeSpan.TotalMinutes);
                ;
                context.SetError("invalid_grant", message);
                //context.Rejected();
                return;
            }

            if (enableLockout & validCredentials == null)
            {
                string message;
                await userManager.AccessFailedAsync(user.Id);

                if (await userManager.IsLockedOutAsync(user.Id))
                {
                    message =
                        string.Format(
                            "Your account has been locked out for {0} minutes due to multiple failed login attempts.",
                            AppSetting.DefaultAccountLockoutTimeSpan.TotalMinutes);
                }
                else
                {
                    var accessFailedCount = await userManager.GetAccessFailedCountAsync(user.Id);
                    var attemptsLeft = AppSetting.MaxFailedAccessAttemptsBeforeLockout -
                                       accessFailedCount;
                    message =
                        string.Format(
                            "Invalid credentials. You have {0} more attempt(s) before your account gets locked out.",
                            attemptsLeft);
                }

                context.SetError("invalid_grant", message);
                //context.Rejected();

                return;
            }
            if (validCredentials == null)
            {

                var message = "Invalid credentials. Please try again.";
                context.SetError("invalid_grant", message);
                //context.Rejected();

                return;
            }
            await userManager.ResetAccessFailedCountAsync(user.Id);
            var oAuthIdentity = await userManager.CreateIdentityAsync(user, OAuthDefaults.AuthenticationType);
            var properties = CreateProperties(user.UserName);


            var oAuthTicket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(oAuthTicket);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }
    }
}