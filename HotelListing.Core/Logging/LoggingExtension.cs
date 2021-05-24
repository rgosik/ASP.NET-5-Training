using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.Logging
{
    public static class LoggingExtension
    {
        public static IHostBuilder UseSerilogLogging(this IHostBuilder builder)
        {
            builder.UseSerilog();

            builder.ConfigureServices((services) => 
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File(
                    path: "d:\\VSLogs\\HotelListing\\log-.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exceprion}",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information)
                    .CreateLogger();
            });

            return builder;
        }
    }
}
