using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simple.IdentityRole.Startup))]
namespace Simple.IdentityRole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
