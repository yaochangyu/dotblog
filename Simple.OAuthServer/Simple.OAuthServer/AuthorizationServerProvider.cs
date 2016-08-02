using System.Threading.Tasks;
using System.Web.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using Simple.OAuthServer.Models;

namespace Simple.OAuthServer
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationIdentityUser user;
            try
            {
                user = await userManager.FindAsync(context.UserName, context.Password);
            }
            catch
            {
                context.SetError("server_error");
                context.Rejected();
                return;
            }
            if (user != null)
            {
                var identity = await userManager.CreateIdentityAsync(user,
                                                                     DefaultAuthenticationTypes.ExternalBearer);
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Invalid User Id or password'");
                context.Rejected();
            }
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