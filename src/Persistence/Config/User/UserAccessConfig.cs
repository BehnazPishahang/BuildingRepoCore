using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.User
{
    public class UserAccessConfig : IEntityTypeConfiguration<Domain.User.UserAccess>
    {
        public void Configure(EntityTypeBuilder<Domain.User.UserAccess> builder)
        {
            throw new NotImplementedException();
        }
    }
}