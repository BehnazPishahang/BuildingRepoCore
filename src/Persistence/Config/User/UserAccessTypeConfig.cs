using Commons;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config.User
{
    public class UserAccessTypeConfig : IEntityTypeConfiguration<UserAccessType>
    {
        public void Configure(EntityTypeBuilder<UserAccessType> builder)
        {
            builder.Property(c=>c.Code).HasMaxLength(4).IsUnicode(false);
            builder.Property(c => c.Title).HasMaxLength(100);

            #region SeedData

            var UserAccessTypeOne = new UserAccessType()
            {
                Id = new Guid("6524FA96-E320-413B-8695-8467C94465EE"),
                Code = "0001",
                Title = "مدیر ساختمان",
                State = Enumerations.State.Active

            };

            var UserAccessTypetwo = new UserAccessType()
            {
                Id = new Guid("FA1D726C-615E-4E89-9AED-477E7CBD7E2B"),
                Code = "0002",
                Title = "اعضای ساختمان",
                State = Enumerations.State.Active

            };
            
            builder.HasData(UserAccessTypeOne);
            builder.HasData(UserAccessTypetwo);

            #endregion SeedData
        }
    }
}