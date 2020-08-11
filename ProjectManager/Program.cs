using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace ProjectManager.PL
{
    public class Program
    {
        public static NLog.Logger Logger = NLogBuilder
            .ConfigureNLog("nlog.config")
            .GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            try
            {
                Logger.Debug("Launch...");
                CreateWebHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception exception)
            {
                Logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
    }
}