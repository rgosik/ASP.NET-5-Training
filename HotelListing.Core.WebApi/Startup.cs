using Autofac;
using HotelListing.Core.BLL.Autofac;
using HotelListing.Core.BLL.Interfaces;
using HotelListing.Core.BLL.Services;
using HotelListing.Core.DataAccess.Repository;
using HotelListing.Core.DataAccess.Repository.Interfaces;
using HotelListing.Core.Logging;
using HotelListing.Core.WebApi.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HotelListing.Core.WebApi
{
    public class Startup
    {
        private static readonly Assembly WebApiAssembly = typeof(HotelListingWebapiModule).Assembly;
        private static readonly Assembly BllAssembly = typeof(HotelListingServicesModule).Assembly;
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(o => {
                o.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddAutoMapper(WebApiAssembly, BllAssembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelListing", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(op => 
                op.SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<HotelListingWebapiModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelListing.Core.WebApi v1"));

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.ConfigureSerilogLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
