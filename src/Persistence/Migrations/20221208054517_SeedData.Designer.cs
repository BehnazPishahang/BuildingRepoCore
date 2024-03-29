﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221208054517_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Building.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FloorCount")
                        .HasColumnType("int");

                    b.Property<int?>("Plaque")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"),
                            Address = "تهران خیابان بهشتی",
                            CityName = "تهران",
                            FloorCount = 4,
                            Plaque = 30,
                            Title = "ساختمان آنو"
                        },
                        new
                        {
                            Id = new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"),
                            Address = "سه راه تقی آباد",
                            CityName = "شهرری",
                            FloorCount = 4,
                            Plaque = 16,
                            Title = "ساختمان مهندس"
                        });
                });

            modelBuilder.Entity("Domain.Cost.Cost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("CashAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CostTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ObjectStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ToDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CostTypeId");

                    b.HasIndex("ObjectStateId");

                    b.ToTable("Costs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("858791a0-03bc-4ba6-acc4-12f7c256f80a"),
                            Amount = 2000m,
                            BuildingId = new Guid("6bf35be1-1677-4245-bba0-622ee23ce9d7"),
                            CashAmount = 30000m,
                            CostTypeId = new Guid("dc59b74c-f132-4943-aad2-5d16161287de"),
                            EventDate = "",
                            FromDate = "1401/01/01",
                            ObjectStateId = new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"),
                            ToDate = "1401/03/01"
                        },
                        new
                        {
                            Id = new Guid("6ee8e8f0-d89a-487b-a1f9-0e13da4026c6"),
                            Amount = 1000m,
                            BuildingId = new Guid("5bc530db-e4ce-4046-ac4a-e0559b48d1a8"),
                            CashAmount = 40000m,
                            CostTypeId = new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"),
                            EventDate = "1401/01/01",
                            ObjectStateId = new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85")
                        });
                });

            modelBuilder.Entity("Domain.Cost.CostType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CostTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc59b74c-f132-4943-aad2-5d16161287de"),
                            Code = "0001",
                            Title = "نظافت ساختمان"
                        },
                        new
                        {
                            Id = new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"),
                            Code = "0002",
                            Title = "قبض برق"
                        });
                });

            modelBuilder.Entity("Domain.ObjectState.ObjectState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ObjectStates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80449d6d-a150-4f8f-a283-5bed489daf19"),
                            Code = "0001",
                            Title = "پرداخت شده"
                        },
                        new
                        {
                            Id = new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"),
                            Code = "0002",
                            Title = "پرداخت نشده"
                        });
                });

            modelBuilder.Entity("Domain.Cost.Cost", b =>
                {
                    b.HasOne("Domain.Building.Building", "TheBuilding")
                        .WithMany("TheCostList")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Cost.CostType", "TheCostType")
                        .WithMany()
                        .HasForeignKey("CostTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ObjectState.ObjectState", "TheObjectState")
                        .WithMany()
                        .HasForeignKey("ObjectStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheBuilding");

                    b.Navigation("TheCostType");

                    b.Navigation("TheObjectState");
                });

            modelBuilder.Entity("Domain.Building.Building", b =>
                {
                    b.Navigation("TheCostList");
                });
#pragma warning restore 612, 618
        }
    }
}
