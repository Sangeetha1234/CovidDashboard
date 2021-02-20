using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CovidDashboardPOC.Startup))]
namespace CovidDashboardPOC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
