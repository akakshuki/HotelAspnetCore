using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class BookRoomConfig : IEntityTypeConfiguration<BookRoom>
    {
        public void Configure(EntityTypeBuilder<BookRoom> builder)
        {
            builder.ToTable("BookRooms");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.Room)
                .WithMany(x => x.BookRooms)
                .HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.Booking)
                .WithMany(x => x.BookRooms)
                .HasForeignKey(x => x.BookingId);
        }
    }
}
