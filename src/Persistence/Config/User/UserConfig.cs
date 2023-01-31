using Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.User
{
    public class UserConfig : IEntityTypeConfiguration<Domain.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User.User> builder)
        {
            #region SeedData

            var UserOne = new Domain.User.User()
            {
                Id = new Guid("75497455-5E77-42FA-87DA-125B7686C3F2"),
                Name = "مجید",
                Family = "عباسی",
                StartDate = "1401/10/20",
                EndDate = "9999/99/99",
                MobileNumber = "09125873154",
                PassWord = Commons.Extensions.StringExtensions.ToHash("1234"),
                NationalCode = "048403716",
                Sex = Enumerations.SexType.Male
            };

            var Usertwo = new Domain.User.User()
            {
                Id = new Guid("D6023CD6-FDE2-423D-A8AC-E2CFBD252BA3"),
                Name = "بهناز",
                Family = "پیشاهنگ",
                StartDate = "1401/10/20",
                EndDate = "9999/99/99",
                MobileNumber = "09359384485",
                PassWord = Commons.Extensions.StringExtensions.ToHash("1234"),
                NationalCode = "1810089666",
                Sex = Enumerations.SexType.Female
            };

            builder.HasData(UserOne);
            builder.HasData(Usertwo);
            
            #endregion SeedData
        }
    }
}