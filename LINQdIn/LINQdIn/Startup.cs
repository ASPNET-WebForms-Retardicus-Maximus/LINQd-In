using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LINQdIn.Startup))]
namespace LINQdIn
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
