﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MornrideApi.Data.Context;

#nullable disable

namespace MornrideApi.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.BannerImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Collection")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("BannerImages");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Bike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.BikeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BikeId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BikesCategories");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.BikeImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BikeId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<string>("HexColor")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("ImagePosition")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.HasIndex("ImageId");

                    b.ToTable("BikeImages");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BikeId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("BikeId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.BannerImage", b =>
                {
                    b.HasOne("MornrideApi.Domain.Entities.Model.Image", "ImageFromBanner")
                        .WithMany("Banners")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageFromBanner");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.BikeCategory", b =>
                {
                    b.HasOne("MornrideApi.Domain.Entities.Model.Bike", "Bike")
                        .WithMany("BikeCategories")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MornrideApi.Domain.Entities.Model.Category", "Category")
                        .WithMany("CategoryBikes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.BikeImage", b =>
                {
                    b.HasOne("MornrideApi.Domain.Entities.Model.Bike", "Bike")
                        .WithMany("BikeImages")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MornrideApi.Domain.Entities.Model.Image", "Image")
                        .WithMany("BikeImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Cart", b =>
                {
                    b.HasOne("MornrideApi.Domain.Entities.Model.Bike", "CurrentBike")
                        .WithOne("CurrentCart")
                        .HasForeignKey("MornrideApi.Domain.Entities.Model.Cart", "BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentBike");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Bike", b =>
                {
                    b.Navigation("BikeCategories");

                    b.Navigation("BikeImages");

                    b.Navigation("CurrentCart");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Category", b =>
                {
                    b.Navigation("CategoryBikes");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Image", b =>
                {
                    b.Navigation("Banners");

                    b.Navigation("BikeImages");
                });
#pragma warning restore 612, 618
        }
    }
}
