﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NewsPaperSystemEntities1 : DbContext
    {
        public NewsPaperSystemEntities1()
            : base("name=NewsPaperSystemEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CusReg> CusRegs { get; set; }
        public virtual DbSet<Dboy> Dboys { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<VendorList> VendorLists { get; set; }
        public virtual DbSet<Vreg> Vregs { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}