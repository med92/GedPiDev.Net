using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GedPiDev.WebPresentationLayer.Startup))]
namespace GedPiDev.WebPresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
