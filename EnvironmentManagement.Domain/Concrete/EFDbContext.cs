using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentManagement.Domain.Entities;

namespace EnvironmentManagement.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<ComponentAttributes> ComponentAttributes { get; set; }
        public DbSet<Components> Components { get; set; }
        public DbSet<EnvironmentComponents> EnvironmentComponents { get; set; }
        public DbSet<EnvironmentUsers> EnvironmentUsers { get; set; }
    }
}
