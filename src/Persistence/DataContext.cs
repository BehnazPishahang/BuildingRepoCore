using Domain;
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

        public DbSet<Cost> Costs { get; set; }

        public DbSet<CostType> CostTypes { get; set; }

        public DbSet<ObjectState> ObjectStates { get; set; }
    }
}
