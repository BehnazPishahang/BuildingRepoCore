using Application.Common;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Domain.User.User> GetByuserANDpass(string Family, string Password)
        {
            var Hashpass=Commons.Extensions.StringExtensions.ToHash(Password);
            return await _context.Set<Domain.User.User>().Where(a => a.Family == Family && a.PassWord == Hashpass)
                .Include(a => a.TheUserAccessList)
                .ThenInclude(a => a.TheUserAccessType)
                .FirstOrDefaultAsync();
                
        }
    }
}
