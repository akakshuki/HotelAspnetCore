using System;
using System.Collections.Generic;
using System.Text;
using Data.Configurations;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.ApplyConfiguration(new AppRoleConfig());
            modelBuilder.ApplyConfiguration(new AppUserConfig());
           
            modelBuilder.ApplyConfiguration(new BookingConfig());
            modelBuilder.ApplyConfiguration(new CategoryRoomConfig());
            modelBuilder.ApplyConfiguration(new CategoryServiceConfig());
            modelBuilder.ApplyConfiguration(new GuestConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());
            modelBuilder.ApplyConfiguration(new RoomConfig());
            modelBuilder.ApplyConfiguration(new ServiceConfig());


            //setting IDentity
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x=>x.Id);
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);


        }

        public DbSet<CategoryRoom> CategoryRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CategoryService> CategoryServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
