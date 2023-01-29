using Application.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;
using ServiceModel.Building;
using ServiceModel.Cost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Building
{
    public class BuildingRepository : GenericRepository<Domain.Building.Building>, Application.Building.IBuildingRepository
    {
        public DataContext _Context { get; }

        public BuildingRepository(DataContext context) : base(context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Domain.Building.Building>> GetbyCityName(string CityName)
        {
            return await _context.Set<Domain.Building.Building>().Where((a => a.CityName == CityName))
                .Include(b => b.TheCostList)
                .Include(b=> b.TheBuildingRegion)
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

        public IEnumerable<Domain.Building.Building> GetBuildingSelectLoading()
        {
            return _context.Set<Domain.Building.Building>().Select(x => new Domain.Building.Building
            {
                CityName = x.CityName,
                Title = x.Title
            });

        }

        public string  AddBuilding(ServiceModel.Building.BuildingContract Request)
        {
            Domain.Building.Building OneBuilding = new Domain.Building.Building
            {
                Plaque=Request.Plaque,
                Address=Request.Address,
                CityName=Request.CityName,
                FloorCount=Request.FloorCount,
                Title =Request.Title
                //,
                //TheCostList = Request.TheCostList.Select(cost => new Domain.Cost.Cost()
                //{
                //    Amount=cost.Amount,
                //    CashAmount=cost.CashAmount,
                //    EventDate=cost.EventDate,
                //    FromDate = cost.FromDate,
                //    TheObjectState= ObjectStateRepository(cost.TheObjectState.Code)
                    
                //}).ToList()
                
                
            };

            _Context.Buildings.Add(OneBuilding);
            _context.SaveChanges();
            string Message = ($"ساختمان {OneBuilding.Title} ذخیره شد.");
            return Message;

        }

    }
}
