using Application.Common;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Building
{
    public interface IBuildingRepository : IGenericRepository<Domain.Building.Building>
    {
        Task<IEnumerable<Domain.Building.Building>> GetbyCityName(string CityName);
    }
}