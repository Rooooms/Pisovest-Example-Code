﻿// <auto-generated />
using System;
using CustomerApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230409110641_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalPurchase")
                        .HasColumnType("int");

                    b.Property<int>("purchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("purchaseId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ProductPrice")
                        .HasColumnType("real");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CustomerApi.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("CustomerApi.Models.Customer", b =>
                {
                    b.HasOne("CustomerApi.Models.Purchase", "purchase")
                        .WithOne("customer")
                        .HasForeignKey("CustomerApi.Models.Customer", "purchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("purchase");
                });

            modelBuilder.Entity("CustomerApi.Models.Product", b =>
                {
                    b.HasOne("CustomerApi.Models.Purchase", null)
                        .WithMany("Products")
                        .HasForeignKey("PurchaseId");
                });

            modelBuilder.Entity("CustomerApi.Models.Purchase", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("customer");
                });
#pragma warning restore 612, 618
        }
    }
}