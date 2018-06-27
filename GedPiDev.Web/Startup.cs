using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GedPiDev.Web.Startup))]
namespace GedPiDev.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
