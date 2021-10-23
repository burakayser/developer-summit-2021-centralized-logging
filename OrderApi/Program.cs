using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperSummit.Core.Helper;
using DeveloperSummit.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DeveloperSummit.OrderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = LoggingHelper.CustomLoggerConfiguration(new CustomLoggerConfigurationModel("OrderApi", "4"));

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                    webBuilder.UseUrls("http://localhost:5103");
                    webBuilder.UseSerilog();
                });
    }
}