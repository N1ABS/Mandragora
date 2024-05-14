using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mandragora.Startup))]
namespace Mandragora
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
