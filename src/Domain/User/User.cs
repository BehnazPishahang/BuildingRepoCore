using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;

namespace Domain.User
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string? NationalCode { get; set; }

        public string PassWord { get; set; }

        public Enumerations.SexType Sex { get; set; }

        public string? MobileNumber { get; set; }

        [Description("دسترسي کاربر ")]
        public virtual List<UserAccess>? TheUserAccessList { get; set; }

    }


}
