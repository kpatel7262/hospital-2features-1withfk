using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospitalproject.Startup))]
namespace Hospitalproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
