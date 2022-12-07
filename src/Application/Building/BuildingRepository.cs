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

    }
}
