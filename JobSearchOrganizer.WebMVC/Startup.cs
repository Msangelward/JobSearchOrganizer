using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobSearchOrganizer.WebMVC.Startup))]
namespace JobSearchOrganizer.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
