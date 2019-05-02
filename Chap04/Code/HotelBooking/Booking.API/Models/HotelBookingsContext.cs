using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Booking.API.Models
{
    public partial class HotelBookingsContext : DbContext
    {
        public HotelBookingsContext()
        {
        }

        public HotelBookingsContext(DbContextOptions<HotelBookingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingsInfo> BookingsInfo { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-TTCGSA2;Database=HotelBookings;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingsInfo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerName).IsRequired();

                entity.Property(e => e.HotelName).HasMaxLength(450);

                entity.Property(e => e.RoomNo).HasMaxLength(50);
            });
        }
    }
}
