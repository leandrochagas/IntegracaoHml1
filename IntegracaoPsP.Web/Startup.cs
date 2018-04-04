using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntegracaoPsP.Web.Startup))]
namespace IntegracaoPsP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
