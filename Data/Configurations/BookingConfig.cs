using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Amount).HasDefaultValue(0);
            builder.Property(x => x.DurationStay).HasDefaultValue(0);

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.RoomId);

            builder.HasOne(x => x.Guest)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.GuestId);
        }
    }
}