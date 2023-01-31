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
            
            #region QueryFilter
            //با این فیلتر بصورت پیش فرض زمانی که روی این جدول ها کوئری میزنیم این فیلترها اعمال میشوند مگر اینکه از
            //IgnoreQueryFilters
            //در هنگام کوئری زدن استفاده کنیم
            builder.HasQueryFilter(o => o.State);
            
            #endregion QueryFilter

            #region SeedData

            var objectStateOne = new Domain.ObjectState.ObjectState()
            {
                Id = new Guid("80449D6D-A150-4F8F-A283-5BED489DAF19"),
                Code = "0001",
                Title = "پرداخت شده",
            };
            
            var objectStateTwo = new Domain.ObjectState.ObjectState()
            {
                Id = new Guid("20F179EF-AB00-40A1-A1A3-BC0E2444BC85"),
                Code = "0002",
                Title = "پرداخت نشده",
            };
            
            builder.HasData(objectStateOne);
            builder.HasData(objectStateTwo);

            #endregion SeedData
        }
    }
}