﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class DinningTableConfiguration : IEntityTypeConfiguration<DiningTable>
    {
        public void Configure(EntityTypeBuilder<DiningTable> builder)
        {
            builder.HasKey(e => e.Id); 
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasIndex(e => e.BranchId).HasDatabaseName("IX_DiningTables_RestaurantBranchId");


            builder.HasOne(d => d.Branch)
                .WithMany(p => p.DinningTables)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_DiningTables_RestaurantBranches_RestaurantBranchId");
        }
    }
}
