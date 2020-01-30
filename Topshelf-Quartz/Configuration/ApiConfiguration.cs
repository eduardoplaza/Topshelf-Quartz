using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Reflection;
using System.Web.Http;

namespace TopshelfQuartz.Configuration
{
    public class ApiConfiguration
    {
        public void Configuration(IAppBuilder app)

        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}
