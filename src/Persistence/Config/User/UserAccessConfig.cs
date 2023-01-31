using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.User
{
    public class UserAccessConfig : IEntityTypeConfiguration<Domain.User.UserAccess>
    {
        public void Configure(EntityTypeBuilder<Domain.User.UserAccess> builder)
        {
            #region SeedData

            builder.HasData(new UserAccess()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("75497455-5E77-42FA-87DA-125B7686C3F2"),
                UserAccessTypeId = Guid.Parse("6524FA96-E320-413B-8695-8467C94465EE"),
                StartDate = "1401/10/20",
                EndDate = "9999/99/99",
                SignText = "مجید عباسی _ مدیر ساختمان"

            });
            
            builder.HasData(new UserAccess()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("D6023CD6-FDE2-423D-A8AC-E2CFBD252BA3"),
                UserAccessTypeId = Guid.Parse("FA1D726C-615E-4E89-9AED-477E7CBD7E2B"),
                StartDate = "1401/10/20",
                EndDate = "9999/99/99",
                SignText = "بهناز پیشاهنگ _ اعضای ساختمان"
            });

            #endregion SeedData
        }
    }
}