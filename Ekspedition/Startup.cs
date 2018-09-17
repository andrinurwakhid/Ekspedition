using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ekspedition.Startup))]
namespace Ekspedition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
