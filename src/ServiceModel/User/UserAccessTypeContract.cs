using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;

namespace ServiceModel.User
{
    public class UserAccessTypeContract
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public Enumerations.State State { get; set; }
    }
}
