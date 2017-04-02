using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CareerPro.Web.Startup))]
namespace CareerPro.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
