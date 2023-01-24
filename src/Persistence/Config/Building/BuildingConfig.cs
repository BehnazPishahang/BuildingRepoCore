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
        }
    }
}