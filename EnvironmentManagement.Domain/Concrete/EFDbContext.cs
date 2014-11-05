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
        public DbSet<COMPONENTATTRIBUTE> ComponentAttribute { get; set; }
        public DbSet<COMPONENTCONNECTION> ComponentConnection { get; set; }
        public DbSet<ENVIRONMENT> Environment { get; set; }
        public DbSet<ENVIRONMENTATTRIBUTE> EnvironmentAttribute { get; set; }
        public DbSet<ENVIRONMENTCOMPONENT> EnvironmentComponent { get; set; }
    }
}
