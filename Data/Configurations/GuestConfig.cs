using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class GuestConfig : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Guest");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FirstName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(300).IsUnicode(false).IsRequired();
            builder.Property(x => x.IdentityNo).HasMaxLength(9);
        }
    }
}