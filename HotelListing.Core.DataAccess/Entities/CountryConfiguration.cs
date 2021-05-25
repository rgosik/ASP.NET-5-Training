using HotelListing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HotelListing.Core.DataAccess.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
