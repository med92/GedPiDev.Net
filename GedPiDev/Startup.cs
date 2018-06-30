using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GedPiDev.Startup))]
namespace GedPiDev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
