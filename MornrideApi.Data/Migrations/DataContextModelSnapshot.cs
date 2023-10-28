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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BackWheel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BikeId")
                        .HasColumnType("int");

                    b.Property<string>("FrontBike")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontWheel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullBike")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HexColor")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.ToTable("BikeImages");
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

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Images", b =>
                {
                    b.HasOne("MornrideApi.Domain.Entities.Model.Bike", "BikeFromThisImage")
                        .WithMany("BikeImages")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BikeFromThisImage");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Bike", b =>
                {
                    b.Navigation("BikeCategories");

                    b.Navigation("BikeImages");
                });

            modelBuilder.Entity("MornrideApi.Domain.Entities.Model.Category", b =>
                {
                    b.Navigation("CategoryBikes");
                });
#pragma warning restore 612, 618
        }
    }
}
