using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class UserAccess: BaseEntity
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string SignText { get; set; }

        public virtual User TheUser { get; set; }

        public Guid UserId { get; set; }

        public virtual UserAccessType TheUserAccessType { get; set; }

        public Guid UserAccessTypeId { get; set; }
    }
}
