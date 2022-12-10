using Domain.Building;
using Domain.Cost;
using Domain.ObjectState;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Cost> Costs { get; set; }

        public DbSet<CostType> CostTypes { get; set; }

        public DbSet<ObjectState> ObjectStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var buildingOne = new Building()
            {
                Id = new Guid("6BF35BE1-1677-4245-BBA0-622EE23CE9D7"),
                Address = "تهران خیابان بهشتی",
                CityName = "تهران",
                FloorCount = 4,
                Plaque = 30,
                Title = "ساختمان آنو",
            };

            var buildingTwo = new Building()
            {
                Id = new Guid("5BC530DB-E4CE-4046-AC4A-E0559B48D1A8"),
                Address = "سه راه تقی آباد",
                CityName = "شهرری",
                FloorCount = 4,
                Plaque = 16,
                Title = "ساختمان مهندس",
            };

            var objectStateOne = new ObjectState()
            {
                Id = new Guid("80449D6D-A150-4F8F-A283-5BED489DAF19"),
                Code = "0001",
                Title = "پرداخت شده",
            };
            var objectStateTwo = new ObjectState()
            {
                Id = new Guid("20F179EF-AB00-40A1-A1A3-BC0E2444BC85"),
                Code = "0002",
                Title = "پرداخت نشده",
            };

            var costTypeOne = new CostType()
            {
                Id = new Guid("DC59B74C-F132-4943-AAD2-5D16161287DE"),
                Code = "0001",
                Title = "نظافت ساختمان",
            };

            var costTypeTwo = new CostType()
            {
                Id = new Guid("170555A9-DE79-4C3C-BB84-098408A8D30A"),
                Code = "0002",
                Title = "قبض برق",
            };
            
            modelBuilder.Entity<Building>().HasData(buildingOne);
            modelBuilder.Entity<Building>().HasData(buildingTwo);

            modelBuilder.Entity<ObjectState>().HasData(objectStateOne);
            modelBuilder.Entity<ObjectState>().HasData(objectStateTwo);
            
            modelBuilder.Entity<CostType>().HasData(costTypeOne);
            modelBuilder.Entity<CostType>().HasData(costTypeTwo);

            modelBuilder.Entity<Cost>()
                .HasData(
                    new Cost()
                    {
                        Id = Guid.NewGuid(),
                        Amount = 2000,
                        CashAmount = 30000,
                        EventDate = string.Empty,
                        FromDate = "1401/01/01",
                        ToDate = "1401/03/01",
                        CostTypeId = Guid.Parse("DC59B74C-F132-4943-AAD2-5D16161287DE"),
                        ObjectStateId = Guid.Parse("80449D6D-A150-4F8F-A283-5BED489DAF19"),
                        BuildingId = Guid.Parse("6BF35BE1-1677-4245-BBA0-622EE23CE9D7")
                    });
            
            modelBuilder.Entity<Cost>()
                .HasData(
                    new Cost()
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1000,
                        CashAmount = 40000,
                        EventDate = "1401/01/01",
                        CostTypeId = Guid.Parse("170555A9-DE79-4C3C-BB84-098408A8D30A"),
                        ObjectStateId = Guid.Parse("20F179EF-AB00-40A1-A1A3-BC0E2444BC85"),
                        BuildingId = Guid.Parse("5BC530DB-E4CE-4046-AC4A-E0559B48D1A8")
                    });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}