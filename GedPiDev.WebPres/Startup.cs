using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GedPiDev.WebPres.Startup))]
namespace GedPiDev.WebPres
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
