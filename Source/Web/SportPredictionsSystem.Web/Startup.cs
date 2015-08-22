using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportPredictionsSystem.Web.Startup))]
namespace SportPredictionsSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
