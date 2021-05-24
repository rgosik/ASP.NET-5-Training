using HotelListing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Core.DataAccess.EntityConfigurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(450);

            builder
                .Property(x => x.ShortName)
                .HasMaxLength(50);
        }
    }
}
