﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogDeneme.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlogDenemeEntities : DbContext
    {
        public BlogDenemeEntities()
            : base("name=BlogDenemeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Blog> Tbl_Blog { get; set; }
        public virtual DbSet<Tbl_BlogKategori> Tbl_BlogKategori { get; set; }
        public virtual DbSet<Tbl_Galeri> Tbl_Galeri { get; set; }
        public virtual DbSet<Tbl_SosyalMedya> Tbl_SosyalMedya { get; set; }
        public virtual DbSet<Tbl_SosyalMedyaIkon> Tbl_SosyalMedyaIkon { get; set; }
        public virtual DbSet<Tbl_Hakkimda> Tbl_Hakkimda { get; set; }
        public virtual DbSet<Tbl_Mesajlar> Tbl_Mesajlar { get; set; }
        public virtual DbSet<Tbl_BlogYorum> Tbl_BlogYorum { get; set; }
        public virtual DbSet<Tbl_Yazar> Tbl_Yazar { get; set; }
        public virtual DbSet<Tbl_Admin> Tbl_Admin { get; set; }
    }
}
