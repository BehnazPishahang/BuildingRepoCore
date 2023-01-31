using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.Cost
{
    public class CostConfig : IEntityTypeConfiguration<Domain.Cost.Cost>
    {
        public void Configure(EntityTypeBuilder<Domain.Cost.Cost> builder)
        {
            builder.HasIndex(c=>c.BuildingId);
            builder.HasIndex(c=>c.CostTypeId);
            builder.HasIndex(c=>c.ObjectStateId);

            #region SeedData

            builder.HasData(new Domain.Cost.Cost()
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

            builder.HasData(new Domain.Cost.Cost()
            {
                Id = Guid.NewGuid(),
                Amount = 1000,
                CashAmount = 40000,
                EventDate = "1401/01/01",
                CostTypeId = Guid.Parse("170555A9-DE79-4C3C-BB84-098408A8D30A"),
                ObjectStateId = Guid.Parse("20F179EF-AB00-40A1-A1A3-BC0E2444BC85"),
                BuildingId = Guid.Parse("5BC530DB-E4CE-4046-AC4A-E0559B48D1A8")
            });

            #endregion
        }
    }
}