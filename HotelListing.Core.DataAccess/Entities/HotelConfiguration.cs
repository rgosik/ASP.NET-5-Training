using HotelListing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HotelListing.Core.DataAccess.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
