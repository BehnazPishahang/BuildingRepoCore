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
    [Migration("20230122074119_AddingStateProperty")]
    partial class AddingStateProperty
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
                            Id = new Guid("a5fd8d95-31d6-4372-bcdd-9f06a05bfd31"),
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
                            Id = new Guid("1c0312f8-9f35-464a-a5e6-81ff618f28f3"),
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

                    b.Property<bool>("State")
                        .HasColumnType("bit");

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
                            State = true,
                            Title = "نظافت ساختمان"
                        },
                        new
                        {
                            Id = new Guid("170555a9-de79-4c3c-bb84-098408a8d30a"),
                            Code = "0002",
                            State = true,
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

                    b.Property<bool>("State")
                        .HasColumnType("bit");

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
                            State = true,
                            Title = "پرداخت شده"
                        },
                        new
                        {
                            Id = new Guid("20f179ef-ab00-40a1-a1a3-bc0e2444bc85"),
                            Code = "0002",
                            State = true,
                            Title = "پرداخت نشده"
                        });
                });

            modelBuilder.Entity("Domain.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75497455-5e77-42fa-87da-125b7686c3f2"),
                            EndDate = "9999/99/99",
                            Family = "عباسی",
                            MobileNumber = "09125873154",
                            Name = "مجید",
                            NationalCode = "048403716",
                            PassWord = "gdyb21LQTcIANtvYMT7QVQ==",
                            Sex = 2,
                            StartDate = "1401/10/20"
                        },
                        new
                        {
                            Id = new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3"),
                            EndDate = "9999/99/99",
                            Family = "پیشاهنگ",
                            MobileNumber = "09359384485",
                            Name = "بهناز",
                            NationalCode = "1810089666",
                            PassWord = "gdyb21LQTcIANtvYMT7QVQ==",
                            Sex = 1,
                            StartDate = "1401/10/20"
                        });
                });

            modelBuilder.Entity("Domain.User.UserAccess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserAccessTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserAccessTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccesses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("567394da-4be9-41e0-a195-04ce0f1fc56d"),
                            EndDate = "9999/99/99",
                            SignText = "مجید عباسی _ مدیر ساختمان",
                            StartDate = "1401/10/20",
                            UserAccessTypeId = new Guid("6524fa96-e320-413b-8695-8467c94465ee"),
                            UserId = new Guid("75497455-5e77-42fa-87da-125b7686c3f2")
                        },
                        new
                        {
                            Id = new Guid("f875701a-e6ab-48f3-a765-e454371704d3"),
                            EndDate = "9999/99/99",
                            SignText = "بهناز پیشاهنگ _ اعضای ساختمان",
                            StartDate = "1401/10/20",
                            UserAccessTypeId = new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"),
                            UserId = new Guid("d6023cd6-fde2-423d-a8ac-e2cfbd252ba3")
                        });
                });

            modelBuilder.Entity("Domain.User.UserAccessType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccessTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6524fa96-e320-413b-8695-8467c94465ee"),
                            Code = "0001",
                            State = 1,
                            Title = "مدیر ساختمان"
                        },
                        new
                        {
                            Id = new Guid("fa1d726c-615e-4e89-9aed-477e7cbd7e2b"),
                            Code = "0002",
                            State = 1,
                            Title = "اعضای ساختمان"
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

            modelBuilder.Entity("Domain.User.UserAccess", b =>
                {
                    b.HasOne("Domain.User.UserAccessType", "TheUserAccessType")
                        .WithMany()
                        .HasForeignKey("UserAccessTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User.User", "TheUser")
                        .WithMany("TheUserAccessList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheUser");

                    b.Navigation("TheUserAccessType");
                });

            modelBuilder.Entity("Domain.Building.Building", b =>
                {
                    b.Navigation("TheCostList");
                });

            modelBuilder.Entity("Domain.User.User", b =>
                {
                    b.Navigation("TheUserAccessList");
                });
#pragma warning restore 612, 618
        }
    }
}
