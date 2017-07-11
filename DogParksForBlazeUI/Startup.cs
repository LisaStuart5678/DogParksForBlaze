using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DogParksForBlazeUI.Startup))]
namespace DogParksForBlazeUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
