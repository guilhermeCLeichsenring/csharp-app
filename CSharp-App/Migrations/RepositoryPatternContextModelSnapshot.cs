﻿// <auto-generated />
using System;
using CSharp_App.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CSharp_App.Migrations
{
    [DbContext(typeof(RepositoryPatternContext))]
    partial class RepositoryPatternContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSharp_App.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedProduct")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("created_date");

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("category");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)")
                        .HasColumnName("description");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("name");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("price");

                    b.Property<int?>("ShelfId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("shelf_id");

                    b.HasKey("Id");

                    b.ToTable("T_PRODUCT");
                });

            modelBuilder.Entity("CSharp_App.Models.ShelfModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ShelfHall")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("shelf_hall");

                    b.HasKey("Id");

                    b.ToTable("T_SHELF");
                });
#pragma warning restore 612, 618
        }
    }
}
