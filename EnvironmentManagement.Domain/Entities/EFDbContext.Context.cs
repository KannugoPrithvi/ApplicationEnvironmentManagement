﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnvironmentManagement.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=EFDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<COMPONENTATTRIBUTE> COMPONENTATTRIBUTES { get; set; }
        public DbSet<COMPONENTCONNECTION> COMPONENTCONNECTIONS { get; set; }
        public DbSet<ENVIRONMENT> ENVIRONMENTs { get; set; }
        public DbSet<ENVIRONMENTATTRIBUTE> ENVIRONMENTATTRIBUTES { get; set; }
        public DbSet<ENVIRONMENTCOMPONENT> ENVIRONMENTCOMPONENTS { get; set; }
    }
}
