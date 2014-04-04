using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharp.Startup))]
namespace CSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
