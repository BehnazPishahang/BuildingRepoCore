using Domain.Building;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.Building;

public class BuildingRegionConfig : IEntityTypeConfiguration<BuildingRegion>
{
    public void Configure(EntityTypeBuilder<BuildingRegion> builder)
    {
        builder.ToTable("Buildings");
    }
}
