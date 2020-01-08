using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(json_upload_data.Startup))]
namespace json_upload_data
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
