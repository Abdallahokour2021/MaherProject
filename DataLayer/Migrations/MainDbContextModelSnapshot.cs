﻿// <auto-generated />
using System;
using DataLayer.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataLayer.Entities.AspNetRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DataLayer.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BlogCardImage")
                        .HasColumnType("longtext");

                    b.Property<string>("BlogMainImage")
                        .HasColumnType("longtext");

                    b.Property<string>("BlogMainText")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SecondaryDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("Video")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("DataLayer.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("DataLayer.Entities.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<float?>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("HotelDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelImage1")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelImage2")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelImage3")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelMainImage")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAC")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsRoomHeater")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTV")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsWifi")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfAdults")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfBathrooms")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfBeds")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfChildren")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfSofas")
                        .HasColumnType("int");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("DataLayer.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<float?>("Discount")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfNights")
                        .HasColumnType("int");

                    b.Property<string>("PackageDetails")
                        .HasColumnType("longtext");

                    b.Property<string>("PackageImage1")
                        .HasColumnType("longtext");

                    b.Property<string>("PackageMainImage")
                        .HasColumnType("longtext");

                    b.Property<int?>("PackageTypeId")
                        .HasColumnType("int");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("RoomClassId")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PackageTypeId");

                    b.HasIndex("RoomClassId");

                    b.HasIndex("UserId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("DataLayer.Entities.PackageOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfAdults")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfChildren")
                        .HasColumnType("int");

                    b.Property<int?>("PackageId")
                        .HasColumnType("int");

                    b.Property<int?>("PackageOrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("PackageOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("PackageOrders");
                });

            modelBuilder.Entity("DataLayer.Entities.PackageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PackageTypes");
                });

            modelBuilder.Entity("DataLayer.Entities.ProviderService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<float?>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("HotelDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelImage1")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelImage2")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelImage3")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelMainImage")
                        .HasColumnType("longtext");

                    b.Property<string>("HotelName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAC")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsRoomHeater")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsShowNotification")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTV")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsWifi")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfBathrooms")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfBeds")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfSofas")
                        .HasColumnType("int");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ProviderServices");
                });

            modelBuilder.Entity("DataLayer.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<int?>("PackageId")
                        .HasColumnType("int");

                    b.Property<int?>("PackageOrderId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("PackageId");

                    b.HasIndex("PackageOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DataLayer.Entities.RoomClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RoomClasses");
                });

            modelBuilder.Entity("DataLayer.Entities.RoomsOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfAdults")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfChildren")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("longtext");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("RoomsOrders");
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetRoleClaim", b =>
                {
                    b.HasOne("DataLayer.Entities.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUserClaim", b =>
                {
                    b.HasOne("DataLayer.Entities.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUserLogin", b =>
                {
                    b.HasOne("DataLayer.Entities.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUserRole", b =>
                {
                    b.HasOne("DataLayer.Entities.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUserToken", b =>
                {
                    b.HasOne("DataLayer.Entities.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.HotelRoom", b =>
                {
                    b.HasOne("DataLayer.Entities.AspNetUser", "User")
                        .WithMany("HotelRooms")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.Package", b =>
                {
                    b.HasOne("DataLayer.Entities.PackageType", "PackageType")
                        .WithMany("Packages")
                        .HasForeignKey("PackageTypeId");

                    b.HasOne("DataLayer.Entities.RoomClass", "RoomClass")
                        .WithMany()
                        .HasForeignKey("RoomClassId");

                    b.HasOne("DataLayer.Entities.AspNetUser", "User")
                        .WithMany("Packages")
                        .HasForeignKey("UserId");

                    b.Navigation("PackageType");

                    b.Navigation("RoomClass");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.PackageOrder", b =>
                {
                    b.HasOne("DataLayer.Entities.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId");

                    b.HasOne("DataLayer.Entities.PackageOrder", null)
                        .WithMany("PackageOrders")
                        .HasForeignKey("PackageOrderId");

                    b.HasOne("DataLayer.Entities.AspNetUser", "User")
                        .WithMany("packageOrders")
                        .HasForeignKey("UserId");

                    b.Navigation("Package");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.ProviderService", b =>
                {
                    b.HasOne("DataLayer.Entities.AspNetUser", "User")
                        .WithMany("providerServices")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.Review", b =>
                {
                    b.HasOne("DataLayer.Entities.HotelRoom", "Hotel")
                        .WithMany("Reviews")
                        .HasForeignKey("HotelId");

                    b.HasOne("DataLayer.Entities.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId");

                    b.HasOne("DataLayer.Entities.PackageOrder", null)
                        .WithMany("Reviews")
                        .HasForeignKey("PackageOrderId");

                    b.HasOne("DataLayer.Entities.AspNetUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("Package");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.RoomsOrder", b =>
                {
                    b.HasOne("DataLayer.Entities.HotelRoom", "Room")
                        .WithMany("RoomOrders")
                        .HasForeignKey("RoomId");

                    b.HasOne("DataLayer.Entities.AspNetUser", "User")
                        .WithMany("RoomsOrders")
                        .HasForeignKey("UserId");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.AspNetUser", b =>
                {
                    b.Navigation("HotelRooms");

                    b.Navigation("Packages");

                    b.Navigation("Reviews");

                    b.Navigation("RoomsOrders");

                    b.Navigation("packageOrders");

                    b.Navigation("providerServices");
                });

            modelBuilder.Entity("DataLayer.Entities.HotelRoom", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("RoomOrders");
                });

            modelBuilder.Entity("DataLayer.Entities.PackageOrder", b =>
                {
                    b.Navigation("PackageOrders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("DataLayer.Entities.PackageType", b =>
                {
                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}
