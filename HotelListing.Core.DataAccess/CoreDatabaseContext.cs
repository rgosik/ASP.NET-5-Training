using HotelListing.Core.DataAccess.Entities;
using HotelListing.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelListing.Core.DataAccess
{
    public class CoreDatabaseContext : IdentityDbContext<ApiUser>
    {
        private const string DatabaseSchemaName = "core";
        private readonly ILoggerFactory _loggerFactory;

        public CoreDatabaseContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_loggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(_loggerFactory);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(CoreDatabaseContext).Assembly);
            builder.HasDefaultSchema(DatabaseSchemaName);
        }
    }
}
