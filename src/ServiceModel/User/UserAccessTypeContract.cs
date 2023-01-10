using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enumerations;

namespace ServiceModel.User
{
    public class UserAccessTypeContract
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public State State { get; set; }
    }
}
