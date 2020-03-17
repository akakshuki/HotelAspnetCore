using Data.Entities;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).HasDefaultValue(0);
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.HasOne(x => x.CategoryService)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.CategoryServiceId);
        }
    }
}