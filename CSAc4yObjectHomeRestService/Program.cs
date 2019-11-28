using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CSAc4yObjectHomeRestService
{
    public class Program
    {
        private const int PORT = 5201;
        private static log4net.ILog _log = log4net.LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("d:\\Server\\Visual_studio\\ac4y\\CSAc4yObjectHomeRestService\\CSAc4yObjectHomeRestService\\log4net.config"));

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                _log.Error(exception.Message);
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:" + PORT)
                .UseKestrel()
                .UseStartup<Startup>();
    }
}
