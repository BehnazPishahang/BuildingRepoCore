using Domain.Building;
using Domain.Cost;
using Domain.ObjectState;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Cost> Costs { get; set; }

        public DbSet<CostType> CostTypes { get; set; }

        public DbSet<ObjectState> ObjectStates { get; set; }
      
        
    }
}
