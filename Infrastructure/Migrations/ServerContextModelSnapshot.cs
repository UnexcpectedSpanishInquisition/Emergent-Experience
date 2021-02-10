﻿// <auto-generated />
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ServerContext))]
    partial class ServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Infrastructure.Server", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("BondMax")
                        .HasColumnType("int");

                    b.Property<int>("Bondxp")
                        .HasColumnType("int");

                    b.Property<int>("DiscoveryMax")
                        .HasColumnType("int");

                    b.Property<int>("Discoveryxp")
                        .HasColumnType("int");

                    b.Property<int>("GoalMax")
                        .HasColumnType("int");

                    b.Property<int>("Goalxp")
                        .HasColumnType("int");

                    b.Property<string>("Prefix")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SetbackMax")
                        .HasColumnType("int");

                    b.Property<int>("Setbackxp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });
#pragma warning restore 612, 618
        }
    }
}