using Commons;
using Domain.Building;
using Domain.Cost;
using Domain.ObjectState;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Persistence.Config.Building;
using Persistence.Config.Cost;
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

        #region DBSets
        public DbSet<Building> Buildings { get; set; }

        public DbSet<Cost> Costs { get; set; }

        public DbSet<CostType> CostTypes { get; set; }

        public DbSet<ObjectState> ObjectStates { get; set; }

        public DbSet<UserAccessType> UserAccessTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAccess> UserAccesses { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Building>(building =>
            {
                building.OwnsOne(d => d.TheBuildingHistory);
                building.OwnsOne(c => c.TheBuildingHistory).ToTable("BuildingHistory");

            }
           );




            #region QueryFilter
            //با این فیلتر بصورت پیش فرض زمانی که روی این جدول ها کوئری میزنیم این فیلترها اعمال میشوند مگر اینکه از
            //IgnoreQueryFilters
            //در هنگام کوئری زدن استفاده کنیم
            modelBuilder.Entity<ObjectState>().HasQueryFilter(o => !o.State);
            modelBuilder.Entity<CostType>().HasQueryFilter(c => !c.State);
            #endregion

         

            var buildingOne = new Building()
            {
                Id = new Guid("6BF35BE1-1677-4245-BBA0-622EE23CE9D7"),
                Address = "تهران خیابان بهشتی",
                CityName = "تهران",
                FloorCount = 4,
                Plaque = 30,
                Title = "ساختمان آنو"
               
                
            };

            var buildingTwo = new Building()
            {
                Id = new Guid("5BC530DB-E4CE-4046-AC4A-E0559B48D1A8"),
                Address = "سه راه تقی آباد",
                CityName = "شهرری",
                FloorCount = 4,
                Plaque = 16,
                Title = "ساختمان مهندس"
               
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

            var UserOne = new User()
            {
                Id = new Guid("75497455-5E77-42FA-87DA-125B7686C3F2"),
                Name = "مجید",
                Family = "عباسی",
                StartDate = "1401/10/20",
                EndDate = "9999/99/99",
                MobileNumber = "09125873154",
                PassWord = Commons.Extensions.StringExtensions.ToHash("1234"),
                NationalCode = "048403716",
                Sex = Enumerations.SexType.Male
            };

            var Usertwo = new User()
            {
                Id = new Guid("D6023CD6-FDE2-423D-A8AC-E2CFBD252BA3"),
                Name = "بهناز",
                Family = "پیشاهنگ",
                StartDate = "1401/10/20",
                EndDate = "9999/99/99",
                MobileNumber = "09359384485",
                PassWord = Commons.Extensions.StringExtensions.ToHash("1234"),
                NationalCode = "1810089666",
                Sex = Enumerations.SexType.Female
            };

            var UserAccessTypeOne = new UserAccessType()
            {
                Id = new Guid("6524FA96-E320-413B-8695-8467C94465EE"),
                Code = "0001",
                Title = "مدیر ساختمان",
                State = Enumerations.State.Active

            };

            var UserAccessTypetwo = new UserAccessType()
            {
                Id = new Guid("FA1D726C-615E-4E89-9AED-477E7CBD7E2B"),
                Code = "0002",
                Title = "اعضای ساختمان",
                State = Enumerations.State.Active

            };

           

            modelBuilder.Entity<Building>().HasData(buildingOne);
            modelBuilder.Entity<Building>().HasData(buildingTwo);

            modelBuilder.Entity<ObjectState>().HasData(objectStateOne);
            modelBuilder.Entity<ObjectState>().HasData(objectStateTwo);

            modelBuilder.Entity<CostType>().HasData(costTypeOne);
            modelBuilder.Entity<CostType>().HasData(costTypeTwo);

            modelBuilder.Entity<User>().HasData(UserOne);
            modelBuilder.Entity<User>().HasData(Usertwo);

            modelBuilder.Entity<UserAccessType>().HasData(UserAccessTypeOne);
            modelBuilder.Entity<UserAccessType>().HasData(UserAccessTypetwo);

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

            modelBuilder.Entity<UserAccess>()
              .HasData(
                  new UserAccess()
                  {
                      Id = Guid.NewGuid(),
                      UserId = Guid.Parse("75497455-5E77-42FA-87DA-125B7686C3F2"),
                      UserAccessTypeId = Guid.Parse("6524FA96-E320-413B-8695-8467C94465EE"),
                      StartDate = "1401/10/20",
                      EndDate = "9999/99/99",
                      SignText = "مجید عباسی _ مدیر ساختمان"

                  });

            modelBuilder.Entity<UserAccess>()
             .HasData(
                 new UserAccess()
                 {
                     Id = Guid.NewGuid(),
                     UserId = Guid.Parse("D6023CD6-FDE2-423D-A8AC-E2CFBD252BA3"),
                     UserAccessTypeId = Guid.Parse("FA1D726C-615E-4E89-9AED-477E7CBD7E2B"),
                     StartDate = "1401/10/20",
                     EndDate = "9999/99/99",
                     SignText = "بهناز پیشاهنگ _ اعضای ساختمان"

                 });

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuildingConfig).Assembly);
            //modelBuilder.ApplyConfiguration(new CostConfig());
            //modelBuilder.ApplyConfiguration(new CostTypeConfig());
            modelBuilder.ApplyConfiguration(new BuildingConfig());


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}