using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LSAppManagement.Startup))]
namespace LSAppManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
