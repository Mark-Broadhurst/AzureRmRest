using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Azure.Application.Service.Startup))]
namespace Azure.Application.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
