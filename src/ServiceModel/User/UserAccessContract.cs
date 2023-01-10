using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.User
{
    public class UserAccessContract
    {
        public Guid Id { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string SignText { get; set; }

        public virtual UserContract TheUser { get; set; }

        public Guid UserId { get; set; }

        public virtual UserAccessTypeContract TheUserAccessType { get; set; }

        public Guid UserAccessTypeId { get; set; }
    }
}
