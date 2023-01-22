using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.User
{
    public class UserAccessTypeConfig : IEntityTypeConfiguration<Domain.User.UserAccessType>
    {
        public void Configure(EntityTypeBuilder<Domain.User.UserAccessType> builder)
        {
            builder.Property(c=>c.Code).HasMaxLength(4).IsUnicode(false);
            builder.Property(c => c.Title).HasMaxLength(100);
        }
    }
}