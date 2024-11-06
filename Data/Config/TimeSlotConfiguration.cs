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
    public class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
    {
        public void Configure(EntityTypeBuilder<TimeSlot> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasIndex(e => e.DinningTableId).HasDatabaseName("IX_TimeSlots_DiningTableId");

            builder.HasOne(d => d.DinningTable)
                .WithMany(p => p.TimeSlots)
                .HasForeignKey(d => d.DinningTableId)
                .HasConstraintName("FK_TimeSlots_DiningTables_DiningTableId");
        }
    }
}
