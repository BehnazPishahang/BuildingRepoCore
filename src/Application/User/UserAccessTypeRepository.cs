using Application.Common;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class UserAccessTypeRepository: GenericRepository<Domain.User.UserAccessType>, IUserAccessTypeRepository
    {
        public UserAccessTypeRepository(DataContext context) : base(context)
        {

        }
    }
}
