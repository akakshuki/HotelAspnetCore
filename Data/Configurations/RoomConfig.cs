using Data.Entities;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.RoomNo).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.HasOne<CategoryRoom>(x => x.CategoryRoom)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.CategoryRoomId);
        }
    }
}