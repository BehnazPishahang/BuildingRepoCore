using Commons;
using Domain.Building;
using Domain.Cost;
using Domain.ObjectState;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Persistence.Config.Building;
using Persistence.Config.Cost;
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

        #region DBSets
        
        public DbSet<Building> Buildings { get; set; }

        public DbSet<Cost> Costs { get; set; }

        public DbSet<CostType> CostTypes { get; set; }

        public DbSet<ObjectState> ObjectStates { get; set; }

        public DbSet<UserAccessType> UserAccessTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAccess> UserAccesses { get; set; }
        
        #endregion DBSets


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuildingConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}