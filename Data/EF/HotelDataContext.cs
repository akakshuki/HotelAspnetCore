using Data.Configurations;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.EF
{
    public class HotelDataContext : DbContext
    {
        public HotelDataContext(DbContextOptions options) : base(options)
        {
        }

        public HotelDataContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config with fluent api
           

            modelBuilder.ApplyConfiguration(new BookingConfig());
            modelBuilder.ApplyConfiguration(new CategoryRoomConfig());
            modelBuilder.ApplyConfiguration(new CategoryServiceConfig());
            modelBuilder.ApplyConfiguration(new GuestConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());
            modelBuilder.ApplyConfiguration(new RoomConfig());
            modelBuilder.ApplyConfiguration(new ServiceConfig());
            modelBuilder.ApplyConfiguration(new BookRoomConfig());

        }

        public DbSet<CategoryRoom> CategoryRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CategoryService> CategoryServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<BookRoom> BookRooms { get; set; }
    }
}