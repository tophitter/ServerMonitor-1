﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bubblegum.Service.EDM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class candykingdomdbEntities : DbContext
    {
        public candykingdomdbEntities()
            : base("name=candykingdomdbEntities")
        {
        }
    
    	public candykingdomdbEntities(string connectionString)
            : base(connectionString)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<servers> servers { get; set; }
        public virtual DbSet<servicemonitor> servicemonitor { get; set; }
        public virtual DbSet<diskmonitor> diskmonitor { get; set; }
        public virtual DbSet<hardwarehistory> hardwarehistory { get; set; }
        public virtual DbSet<procmonitorcpu> procmonitorcpu { get; set; }
        public virtual DbSet<procmonitorram> procmonitorram { get; set; }
        public virtual DbSet<eventmonitor> eventmonitor { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
    }
}
