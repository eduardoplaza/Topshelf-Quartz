using Microsoft.Owin.Hosting;
using System;
using Topshelf;

namespace TopshelfQuartz.Configuration
{
    public class HostingServiceConfiguration : ServiceControl
    {
        private IDisposable _webApplication;


        public bool Start(HostControl hostControl)
        {
            _webApplication = WebApp.Start<Startup>("http://localhost:4500");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _webApplication.Dispose();
            return true;
        }
    }
}
