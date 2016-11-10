using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarFuel.Web.Startup))]
namespace CarFuel.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
