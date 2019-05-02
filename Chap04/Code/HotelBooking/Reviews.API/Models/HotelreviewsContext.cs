using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Reviews.API.Models
{
    public partial class HotelreviewsContext : DbContext
    {
        public HotelreviewsContext()
        {
        }

        public HotelreviewsContext(DbContextOptions<HotelreviewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reviews> Reviews { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("HotelReviewsDb");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.HotelId)
                    .HasColumnName("HotelID")
                    .HasMaxLength(450);
            });
        }
    }
}
