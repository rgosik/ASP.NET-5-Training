using Autofac;
using HotelListing.Core.DataAccess.Repository;
using HotelListing.Core.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.DataAccess.Autofac
{
    public class HotelListingDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
                var loggerFactory = c.Resolve<ILoggerFactory>();
                var opt = new DbContextOptionsBuilder<CoreDatabaseContext>();
                opt.UseSqlServer(config.GetConnectionString("sqlConnection"));

                return new CoreDatabaseContext(opt.Options, loggerFactory);

            }).InstancePerLifetimeScope().AsSelf();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();
        }
    }
}
