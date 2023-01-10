using Application.Common;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class UserAccessRepository : GenericRepository<Domain.User.UserAccess>, IUserAccessRepository
    {
        public UserAccessRepository(DataContext context) : base(context)
        {
                
        }
    }
}
