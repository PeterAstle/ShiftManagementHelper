using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShiftManagementHelper.WebMVC.Startup))]
namespace ShiftManagementHelper.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
