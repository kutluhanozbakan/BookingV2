using BookingV2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Infrastructure.Configurations
{
    public class PersonRefreshTokenConfiguration : IEntityTypeConfiguration<PersonRefreshToken>
    {
        public void Configure(EntityTypeBuilder<PersonRefreshToken> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x=> x.Code).IsRequired().HasMaxLength(200);
        }
    }
}
