using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IP_Project.Startup))]
namespace IP_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
