using Application.Common;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class UserRepository : GenericRepository<Domain.User.User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
                
        }
    }
}
