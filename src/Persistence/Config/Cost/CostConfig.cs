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
        }
    }
}