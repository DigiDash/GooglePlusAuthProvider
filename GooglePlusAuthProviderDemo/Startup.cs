using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GooglePlusAuthProviderDemo.Startup))]
namespace GooglePlusAuthProviderDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
