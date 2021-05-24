using HotelListing.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.DataAccess
{
    public class CoreDatabaseContext : DbContext
    {
        private const string DatabaseSchemaName = "core";
        public CoreDatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDatabaseContext).Assembly);
            modelBuilder.HasDefaultSchema(DatabaseSchemaName);
        }
    }
}
