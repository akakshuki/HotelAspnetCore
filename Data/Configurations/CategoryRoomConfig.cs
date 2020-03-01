using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Configurations
{
    internal class CategoryRoomConfig : IEntityTypeConfiguration<CategoryRoom>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CategoryRoom> builder)
        {
            builder.ToTable("CategoryRooms");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}