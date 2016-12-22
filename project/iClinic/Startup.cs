using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iClinic.Startup))]
namespace iClinic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
