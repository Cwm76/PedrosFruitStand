using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PedrosFruitStand.Startup))]
namespace PedrosFruitStand
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
