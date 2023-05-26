﻿// <auto-generated />
using System;
using BigBangAssessment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigBangAssessment.Migrations.HotelRooms
{
    [DbContext(typeof(HotelRoomsContext))]
    partial class HotelRoomsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BigBangAssessment.Models.Bookings", b =>
                {
                    b.Property<int>("BId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BId"));

                    b.Property<string>("BDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("BId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BigBangAssessment.Models.Hotel", b =>
                {
                    b.Property<int>("Hid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hid"));

                    b.Property<string>("HCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HPhone")
                        .HasColumnType("int");

                    b.Property<string>("HState")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hid");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("BigBangAssessment.Models.Rooms", b =>
                {
                    b.Property<int>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RId"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RPrice")
                        .HasColumnType("int");

                    b.Property<string>("RType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RId");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BigBangAssessment.Models.Bookings", b =>
                {
                    b.HasOne("BigBangAssessment.Models.Rooms", "Rooms")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("BigBangAssessment.Models.Rooms", b =>
                {
                    b.HasOne("BigBangAssessment.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("BigBangAssessment.Models.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("BigBangAssessment.Models.Rooms", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
