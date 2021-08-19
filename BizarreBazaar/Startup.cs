using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BizarreBazaar.Startup))]
namespace BizarreBazaar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
