﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Predavanje6___EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DOTNPredavanje6Entities : DbContext
    {
        public DOTNPredavanje6Entities()
            : base("name=DOTNPredavanje6Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Drzave> Drzave { get; set; }
        public virtual DbSet<Slucajevi> Slucajevi { get; set; }
    }
}
