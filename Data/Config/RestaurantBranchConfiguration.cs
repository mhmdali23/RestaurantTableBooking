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
    public class RestaurantBranchConfiguration : IEntityTypeConfiguration<RestaurantBranch>
    {
        public void Configure(EntityTypeBuilder<RestaurantBranch> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasIndex(e => e.RestaurantId).HasDatabaseName("IX_RestaurantBranches_RestaurantId");

            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.Email).HasMaxLength(50);
            builder.Property(e => e.ImageUrl).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Phone).HasMaxLength(20);

            builder.HasOne(d => d.Restaurant)
                .WithMany(p => p.RestaurantBranches)
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
