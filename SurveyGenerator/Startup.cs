using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurveyGenerator.Startup))]
namespace SurveyGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
