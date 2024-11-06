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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasIndex(e => e.TimeSlotId).HasDatabaseName("IX_Reservations_TimeSlotId");
            builder.HasIndex(e => e.UserId).HasDatabaseName("IX_Reservations_UserId");

            builder.HasOne(d => d.TimeSlot)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TimeSlotId);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId);
        }
    }
}
