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

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CoreDatabaseContext).Assembly);
            builder.HasDefaultSchema(DatabaseSchemaName);

            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "United Stated",
                    ShortName = "USA"
                },
                new Country
                {
                    Id = 2,
                    Name = "Poland",
                    ShortName = "PL"
                },
                new Country
                {
                    Id = 3,
                    Name = "Norway",
                    ShortName = "NOR"
                }
            );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Arcadia",
                    Address = "Busy Street 3",
                    Rating = "4.6",
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Pearl",
                    Address = "Tetris 28",
                    Rating = "3.2",
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Portos",
                    Address = "Marshal's 42",
                    Rating = "4.1",
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 4,
                    Name = "SolidOne",
                    Address = "Marble Street 1",
                    Rating = "5",
                    CountryId = 3
                }
            );
        }
    }
}
