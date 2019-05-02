using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using OnlineHotel.Infra.Domain.Models;

namespace OnlineHotel.Infra.Data.Context
{
    public partial class OnlineHotelContext : DbContext
    {
        public OnlineHotelContext()
        {
        }

        public OnlineHotelContext(DbContextOptions<OnlineHotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HotelBookingDdds> HotelBookingDdds { get; set; }
        public virtual DbSet<HotelCategories> HotelCategories { get; set; }
        public virtual DbSet<HotelFacilities> HotelFacilities { get; set; }
        public virtual DbSet<HotelImageGallery> HotelImageGallery { get; set; }
        public virtual DbSet<HotelRooms> HotelRooms { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }

        // Unable to generate entity type for table 'dbo.HotelReviews'. Please see the warning messages.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelBookingDdds>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("HotelBooking_DDDs");

                entity.Property(e => e.BookingId)
                    .HasColumnName("BookingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.ChekInDate).HasColumnType("datetime");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.InvoiveNumber).HasMaxLength(50);

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelBookingDdds)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelBooking_DDDs_Hotels");
            });

            modelBuilder.Entity<HotelCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<HotelFacilities>(entity =>
            {
                entity.HasKey(e => e.FacilitiesId);

                entity.Property(e => e.FacilitiesId).ValueGeneratedNever();

                entity.Property(e => e.FacilityName).HasMaxLength(50);

                entity.Property(e => e.IconUrl).HasMaxLength(200);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelFacilities)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelFacilities_Hotels");
            });

            modelBuilder.Entity<HotelImageGallery>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).ValueGeneratedNever();

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelImageGallery)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelImageGallery_Hotels");
            });

            modelBuilder.Entity<HotelRooms>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelRooms)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelRooms_Hotels");
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.HasKey(e => e.HotelId);

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HotelPolicy).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PrimaryContactPerson).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Hotels_HotelCategories");
            });
        }
    }
}
