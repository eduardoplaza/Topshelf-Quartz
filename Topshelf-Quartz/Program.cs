using TopshelfQuartz.Configuration;
using Topshelf;

namespace TopshelfQuartz
{
    class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<HostingServiceConfiguration>();

                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.SetServiceName("TopshelfQuarthApi");
                x.SetDisplayName("TopshelfQuarthApi");
                x.SetDescription("Ejemplo de Api contenida en Topshelf y programador de tareas Quarth");
            });
        }
    }
}
