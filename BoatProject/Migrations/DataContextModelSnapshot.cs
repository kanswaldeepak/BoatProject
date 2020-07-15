﻿// <auto-generated />
using System;
using BoatProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoatProject.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoatProject.Models.BoatDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoatImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoatRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RentEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Boats");
                });
#pragma warning restore 612, 618
        }
    }
}
