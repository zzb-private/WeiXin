using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeiXin.Manager.Startup))]
namespace WeiXin.Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
