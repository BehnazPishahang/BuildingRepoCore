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
        }
    }
}