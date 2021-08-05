using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineAppointment.Startup))]
namespace OnlineAppointment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
