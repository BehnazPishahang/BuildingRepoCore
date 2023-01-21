using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.ObjectState
{
    public class ObjectStateConfig : IEntityTypeConfiguration<Domain.ObjectState.ObjectState>
    {
        public void Configure(EntityTypeBuilder<Domain.ObjectState.ObjectState> builder)
        {
            builder.Property(c=>c.Code).HasMaxLength(4).IsUnicode(false);
            builder.Property(c => c.Title).HasMaxLength(100);
        }
    }
}