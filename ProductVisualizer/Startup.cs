using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductVisualizer.Startup))]
namespace ProductVisualizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
