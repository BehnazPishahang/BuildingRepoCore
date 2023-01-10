using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enumerations;

namespace ServiceModel.User
{
    public class UserContract
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string? NationalCode { get; set; }

        public string PassWord { get; set; }

        public SexType Sex { get; set; }

        public string? MobileNumber { get; set; }
    }
}
