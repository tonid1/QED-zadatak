using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Qed.Startup))]
namespace Qed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
