using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.SimpleWebFormsApp.Startup))]
namespace _02.SimpleWebFormsApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
