using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MircheeMusic.Startup))]
namespace MircheeMusic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
