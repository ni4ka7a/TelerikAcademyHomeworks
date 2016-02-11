using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_04.WorkingWithData.Web.Startup))]
namespace _04.WorkingWithData.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
