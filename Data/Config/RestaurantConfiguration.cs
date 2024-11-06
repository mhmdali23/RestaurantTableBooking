using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r=>r.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.Email).HasMaxLength(50);
            builder.Property(e => e.ImageUrl).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Phone).HasMaxLength(20);
        }
    }
}
