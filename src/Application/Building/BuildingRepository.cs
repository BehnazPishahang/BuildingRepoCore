using Application.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Building
{
    public class BuildingRepository : GenericRepository<Domain.Building.Building>, Application.Building.IBuildingRepository
    {

        public BuildingRepository(DataContext context) : base(context)
        {

        }
        
        public async Task<IEnumerable<Domain.Building.Building>> GetbyCityName(string CityName)
        {
            return await _context.Set<Domain.Building.Building>().Where((a=> a.CityName==CityName))
                .Include(b => b.TheCostList)
                .ToListAsync();
        }

    }
}
