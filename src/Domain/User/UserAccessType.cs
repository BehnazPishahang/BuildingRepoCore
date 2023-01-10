using Commons;
using Domain.Common;

namespace Domain.User
{
    public class UserAccessType:BaseEntity
    {

        public string Code { get; set; }

        public string Title { get; set; }

        public Enumerations.State State { get; set; }
    }
}
