using HotelListing.Commons.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.DataAccess.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = nameof(Roles.User),
                    NormalizedName = nameof(Roles.User).ToUpper()
                },
                new IdentityRole
                {
                    Name = nameof(Roles.Administrator),
                    NormalizedName = nameof(Roles.Administrator).ToUpper()
                }
            );
        }
    }
}
