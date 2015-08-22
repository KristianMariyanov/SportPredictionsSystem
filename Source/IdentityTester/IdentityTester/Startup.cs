using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityTester.Startup))]
namespace IdentityTester
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
