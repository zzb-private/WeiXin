using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeiXin.Web.Startup))]
namespace WeiXin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
