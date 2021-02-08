using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelManager.Startup))]
namespace TravelManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
