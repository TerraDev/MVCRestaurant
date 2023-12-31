﻿// <auto-generated />
using System;
using MVCRestaurant.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCRestaurant.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230821161304_no_op")]
    partial class no_op
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "D0074DD6-E540-45D4-A804-5E1A42C81661",
                            ConcurrencyStamp = "8fa56791-479b-45c8-8d26-1900c1893a52",
                            Name = "Customer"
                        },
                        new
                        {
                            Id = "5E1C722F-5CD8-45F4-94A9-14508F2C8E54",
                            ConcurrencyStamp = "ef6cb803-b184-49c0-8c39-043b4c7da27e",
                            Name = "Employee"
                        },
                        new
                        {
                            Id = "29D9873B-8339-4E70-8DE4-544507529A74",
                            ConcurrencyStamp = "bdad63ae-a484-4f42-b121-e91bf2274bf6",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = "15337A34-8592-4417-8C9E-ACF960B00102",
                            ConcurrencyStamp = "58d0536b-43cf-4d3b-9cf1-1f3fba59dbb5",
                            Name = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "B37C0271-DDD7-4124-AD52-69360F5A219F",
                            RoleId = "15337A34-8592-4417-8C9E-ACF960B00102"
                        },
                        new
                        {
                            UserId = "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                            RoleId = "29D9873B-8339-4E70-8DE4-544507529A74"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MVCRestaurant.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("AltKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("AltKey"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "B37C0271-DDD7-4124-AD52-69360F5A219F",
                            AccessFailedCount = 0,
                            AltKey = 1m,
                            ConcurrencyStamp = "5446cab2-6714-43c0-99cf-e75e63362a26",
                            Email = "Sadmin@g.com",
                            EmailConfirmed = true,
                            Latitude = 0f,
                            LockoutEnabled = false,
                            Longitude = 0f,
                            NormalizedEmail = "SADMIN@G.COM",
                            NormalizedUserName = "ادمین کل",
                            PasswordHash = "AQAAAAEAACcQAAAAEOzRmW5WFh9lQYCTz3f/a5iTaMLwdXW7MbwQZj4wxyTVAKRfLy9okt27dlZzg96WWg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fe489586-b5ab-47b0-b070-9b07187431c0",
                            TwoFactorEnabled = false,
                            UserName = "ادمین کل"
                        },
                        new
                        {
                            Id = "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
                            AccessFailedCount = 0,
                            AltKey = 2m,
                            ConcurrencyStamp = "a3c9598b-c2e7-465c-b130-7c81dfbedf98",
                            Email = "admin@g.com",
                            EmailConfirmed = true,
                            Latitude = 0f,
                            LockoutEnabled = false,
                            Longitude = 0f,
                            NormalizedEmail = "ADMIN@G.COM",
                            NormalizedUserName = "ادمین",
                            PasswordHash = "AQAAAAEAACcQAAAAEKcJYBng2cH3iyKxXr0XIwoQlI5uygLnWY3QuFrFVlmRdgpHX6WCDZQGUV/rnY9Rsw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "72a823e0-4ed9-4944-8289-d9a2158ec860",
                            TwoFactorEnabled = false,
                            UserName = "ادمین"
                        });
                });

            modelBuilder.Entity("MVCRestaurant.Models.FoodCategory", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("bit");

                    b.Property<string>("LastDeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FoodCategories");
                });

            modelBuilder.Entity("MVCRestaurant.Models.FoodItem", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<decimal>("CategoryId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("bit");

                    b.Property<string>("LastDeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("MVCRestaurant.Models.Log", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ErrorEncountered")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("MVCRestaurant.Models.Order", b =>
                {
                    b.Property<string>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(20,0)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Tax")
                        .HasColumnType("real");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal?>("UserId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Identifier");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MVCRestaurant.Models.OrderItem", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("OrderedFoodId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderedFoodId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MVCRestaurant.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MVCRestaurant.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCRestaurant.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MVCRestaurant.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCRestaurant.Models.FoodItem", b =>
                {
                    b.HasOne("MVCRestaurant.Models.FoodCategory", "Category")
                        .WithMany("FoodItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MVCRestaurant.Models.Order", b =>
                {
                    b.HasOne("MVCRestaurant.Models.AppUser", "OrderedBy")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("AltKey")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("OrderedBy");
                });

            modelBuilder.Entity("MVCRestaurant.Models.OrderItem", b =>
                {
                    b.HasOne("MVCRestaurant.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MVCRestaurant.Models.FoodItem", "OrderedFood")
                        .WithMany("CorrespondingOrders")
                        .HasForeignKey("OrderedFoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("OrderedFood");
                });

            modelBuilder.Entity("MVCRestaurant.Models.AppUser", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MVCRestaurant.Models.FoodCategory", b =>
                {
                    b.Navigation("FoodItems");
                });

            modelBuilder.Entity("MVCRestaurant.Models.FoodItem", b =>
                {
                    b.Navigation("CorrespondingOrders");
                });

            modelBuilder.Entity("MVCRestaurant.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
