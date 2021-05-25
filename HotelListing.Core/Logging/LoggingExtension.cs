using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

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
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    buffered: true,
                    retainedFileCountLimit: 1,
                    restrictedToMinimumLevel: LogEventLevel.Information)
                    .CreateLogger();
            });

            return builder;
        }

        public static void ConfigureSerilogLogging(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}
