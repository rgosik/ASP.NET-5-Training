using HotelListing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Core.DataAccess.EntityConfigurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(450);

            builder
                .Property(x => x.Address)
                .HasMaxLength(450);

            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Hotels)
                .HasForeignKey(x => x.CountryId);
        }
    }
}
