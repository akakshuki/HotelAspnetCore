using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class CategoryServiceConfig : IEntityTypeConfiguration<CategoryService>
    {
        public void Configure(EntityTypeBuilder<CategoryService> builder)
        {
            builder.ToTable("CategoryService");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            
            

        }
    }
}
