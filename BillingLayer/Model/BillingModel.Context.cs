﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BillingLayer.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BillingAppDBEntities : DbContext
    {
        public BillingAppDBEntities()
            : base("name=BillingAppDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BILLING_TAX_INFO> BILLING_TAX_INFO { get; set; }
        public virtual DbSet<BRAND> BRANDS { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERS { get; set; }
        public virtual DbSet<PRODUCT_TYPE> PRODUCT_TYPE { get; set; }
        public virtual DbSet<TAX> TAXES { get; set; }
        public virtual DbSet<BILLING_INFO> BILLING_INFO { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
        public virtual DbSet<RETAILER> RETAILERS { get; set; }
        public virtual DbSet<BILLING> BILLINGS { get; set; }
        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
    }
}
