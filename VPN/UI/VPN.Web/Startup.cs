using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VPN.Web.Startup))]
namespace VPN.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
