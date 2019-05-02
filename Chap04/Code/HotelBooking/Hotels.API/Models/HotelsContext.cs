using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hotels.API.Models
{
    public partial class HotelsContext : DbContext
    {
       

        public HotelsContext(DbContextOptions<HotelsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Facilities> Facilities { get; set; }
        public virtual DbSet<HotelAddress> HotelAddress { get; set; }
        public virtual DbSet<HotelsInfo> HotelsInfo { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<ItemImageRelationships> ItemImageRelationships { get; set; }
        public virtual DbSet<RoomFacilitiesRelationships> RoomFacilitiesRelationships { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<RoomTypes> RoomTypes { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-TTCGSA2;Database=Hotels;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facilities>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Icon).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<HotelAddress>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelAddress)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelAddress_HotelsInfo");
            });

            modelBuilder.Entity<HotelsInfo>(entity =>
            {
                entity.HasKey(e => e.HotelId);

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.HotelName).HasMaxLength(50);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoomId)
                    .HasColumnName("RoomID")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.RoomId);
            });

            modelBuilder.Entity<ItemImageRelationships>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.ImageId });

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.ItemImageRelationships)
                    .HasForeignKey(d => d.ImageId);
            });

            modelBuilder.Entity<RoomFacilitiesRelationships>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.FeatureId });

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.RoomFacilitiesRelationships)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_RoomFeatureRelationships_Features_FeatureID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomFacilitiesRelationships)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_RoomFeatureRelationships_Rooms_RoomID");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.RoomTypeId)
                    .HasColumnName("RoomTypeID")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Rooms_Hotels");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RoomTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
