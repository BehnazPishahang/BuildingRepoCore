using Domain.Building;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.Building
{
    public class BuildingConfig : IEntityTypeConfiguration<Domain.Building.Building>
    {
        public void Configure(EntityTypeBuilder<Domain.Building.Building> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(500).IsUnicode(false);
            builder.HasIndex(c=> c.Title);

            #region OwnedType

            builder.OwnsOne(d => d.TheBuildingHistory);
            builder.OwnsOne(c => c.TheBuildingHistory).ToTable("BuildingHistory");

            #endregion OwnedType
            
            #region TableSplittingForBuilding
            
            builder.HasOne(c => c.TheBuildingRegion).WithOne().HasForeignKey<BuildingRegion>(c => c.Id);
            builder.ToTable("Buildings");
                
            #endregion TableSplittingForBuilding

            #region SeedData

            var buildingOne = new Domain.Building.Building()
            {
                Id = new Guid("6BF35BE1-1677-4245-BBA0-622EE23CE9D7"),
                Address = "تهران خیابان بهشتی",
                CityName = "تهران",
                FloorCount = 4,
                Plaque = 30,
                Title = "ساختمان آنو"
               
                
            };

            var buildingTwo = new Domain.Building.Building()
            {
                Id = new Guid("5BC530DB-E4CE-4046-AC4A-E0559B48D1A8"),
                Address = "سه راه تقی آباد",
                CityName = "شهرری",
                FloorCount = 4,
                Plaque = 16,
                Title = "ساختمان مهندس"
               
            };
            
            builder.HasData(buildingOne);
            builder.HasData(buildingTwo);

            #endregion SeedData
        }
    }
}