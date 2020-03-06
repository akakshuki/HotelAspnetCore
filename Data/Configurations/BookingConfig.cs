using Data.Entities;
using Data.Enums;
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
            builder.Property(x => x.SecretCode).HasMaxLength(6);
            builder.Property(x => x.Amount).HasDefaultValue(0);
            builder.Property(x => x.Status).HasDefaultValue(BookedStatus.booking).HasMaxLength(20);
            builder.Property(x => x.DurationStay).HasDefaultValue(0);

           

            builder.HasOne(x => x.Guest)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.GuestId);
        }
    }
}