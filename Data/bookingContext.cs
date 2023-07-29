using System;
using System.Collections.Generic;
using Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity;

namespace Booking.Data
{
    public partial class bookingContext : IdentityDbContext
    {
        public bookingContext()
        {
        }

        public bookingContext(DbContextOptions<bookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amenity> Amenities { get; set; } = null!;
        public virtual DbSet<My_Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.Property(e => e.AmenityId)
                    .ValueGeneratedNever()
                    .HasColumnName("amenity_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<My_Booking>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date").HasColumnName("check_in_date");
                entity.Property(e => e.CheckOutDate).HasColumnType("date").HasColumnName("check_out_date");
                entity.Property(e => e.OtherDetails).HasMaxLength(255).IsUnicode(false).HasColumnName("other_details");
                entity.Property(e => e.RoomId).HasColumnName("room_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                // Định nghĩa khóa chính của bảng My_Booking
                entity.HasKey(e => new { e.UserId, e.RoomId, e.Date }).HasName("PK_My_Booking");

                // Xác định mối quan hệ với bảng Payment thông qua thuộc tính UserId, PaymentDate, và RoomId
                entity.HasMany(d => d.Payments)
                      .WithOne(p => p.Booking)
                      .HasForeignKey(d => new { d.UserId, d.Date, d.RoomId })
                      .HasConstraintName("FK__Payments__booking__1367E606");
                entity.HasOne(d => d.User)
                        .WithMany()
                        .HasForeignKey(d => d.UserId)
                        .HasConstraintName("FK_My_Booking_AspNetUsers"); // Đặt tên cho khóa ngoại nếu cần thiết
           
        });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelId)
                    .ValueGeneratedNever()
                    .HasColumnName("hotel_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OtherDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("other_details");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)").HasColumnName("amount");
                entity.Property(e => e.OtherDetails).HasMaxLength(255).IsUnicode(false).HasColumnName("other_details");
                entity.Property(e => e.Date).HasColumnType("date").HasColumnName("payment_date");
                entity.Property(e => e.PaymentMethod).HasMaxLength(100).IsUnicode(false).HasColumnName("payment_method");

                // Định nghĩa khóa chính của bảng Payment
                entity.HasKey(e => new { e.UserId, e.Date, e.RoomId });

                // Xác định mối quan hệ với bảng My_Booking thông qua thuộc tính UserId, PaymentDate, và RoomId
                entity.HasOne(d => d.Booking)
                      .WithMany(p => p.Payments)
                      .HasPrincipalKey(p => new { p.UserId, p.Date, p.RoomId }) // Dùng HasPrincipalKey()
                      .HasConstraintName("FK__Payments__booking__1367E606");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("room_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.OtherDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("other_details");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.status).HasColumnName("status");


                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK__Rooms__hotel_id__08EA5793");

                entity.HasMany(d => d.Amenities)
                    .WithMany(p => p.Rooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoomAmenity",
                        l => l.HasOne<Amenity>().WithMany().HasForeignKey("AmenityId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__RoomAmeni__ameni__20C1E124"),
                        r => r.HasOne<Room>().WithMany().HasForeignKey("RoomId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__RoomAmeni__room___1FCDBCEB"),
                        j =>
                        {
                            j.HasKey("RoomId", "AmenityId").HasName("PK__RoomAmen__D7F7DED81DE57479");

                            j.ToTable("RoomAmenities");

                            j.IndexerProperty<int>("RoomId").HasColumnName("room_id");

                            j.IndexerProperty<int>("AmenityId").HasColumnName("amenity_id");
                        });
                    entity.HasOne(d => d.RoomType)
                           .WithMany()
                           .HasForeignKey(d => d.RoomTypeId)
                           .HasConstraintName("FK_Room_RoomType");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("room_type_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
