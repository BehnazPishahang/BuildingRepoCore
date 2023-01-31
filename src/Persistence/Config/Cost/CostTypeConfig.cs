using Domain.Cost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.Cost
{
    public class CostTypeConfig : IEntityTypeConfiguration<Domain.Cost.CostType>
    {
        public void Configure(EntityTypeBuilder<Domain.Cost.CostType> builder)
        {
            builder.Property(c=>c.Code).HasMaxLength(4).IsUnicode(false);
            builder.Property(c => c.Title).HasMaxLength(100);
            builder.HasQueryFilter(o => o.State);

            #region SeedData

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

            builder.HasData(costTypeOne);
            builder.HasData(costTypeTwo);
            
            #endregion SeedData
        }
    }
}