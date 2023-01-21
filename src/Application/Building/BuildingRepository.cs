using Application.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;
using ServiceModel.Building;
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
            return await _context.Set<Domain.Building.Building>().Where((a => a.CityName == CityName))
                .Include(b => b.TheCostList)
                .ToListAsync();
        }


        public async Task<IEnumerable<Domain.Building.Building>> GetBuildingEager()
        {
            return await _context.Set<Domain.Building.Building>().Include(b => b.TheCostList)
                .ToListAsync();
        }

        public IEnumerable<Domain.Building.Building> GetBuildingExplicit()
        {

            var Buildingresult = _context.Buildings.Where(b => EF.Functions.Like(b.CityName, "%تهر%")).ToList();

            foreach (var Building in Buildingresult)
            {
                //explicit loading for List
                _context.Entry(Building).Collection(c => c.TheCostList).Load();

                foreach (var Cost in Building.TheCostList)
                {
                    //explicit loading for Object
                    _context.Entry(Cost).Reference(x => x.TheCostType).Load();
                }


            }
            return Buildingresult;


        }

        public IEnumerable<BuildingContract> GetBuildingSelectLoading()
        {
            return _context.Set<Domain.Building.Building>().Select(x => new BuildingContract
            {
                CityName = x.CityName,
                Title = x.Title
            });

        }




    }
}
