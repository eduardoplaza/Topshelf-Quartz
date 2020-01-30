using Owin;
using System.Web.Http;

namespace TopshelfQuartz.Configuration
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ApiConfiguration(app);
            QuartzConfiguration();
        }

        private void ApiConfiguration(IAppBuilder app)
        {
            //activa configuración de rutas y autofac
            ApiConfiguration apiConfig = new ApiConfiguration();
            apiConfig.Configuration(app);
        }

        private void QuartzConfiguration()
        {
            //activa configuracion de Quartz
            QuartzServiceConfiguration quartz = new QuartzServiceConfiguration();
            quartz.Start();
        }
    }
}
