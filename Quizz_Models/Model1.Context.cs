﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quizz_Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bdd_quizz_Entities : DbContext
    {
        public bdd_quizz_Entities()
            : base("name=bdd_quizz_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<compte> compte { get; set; }
        public virtual DbSet<question> question { get; set; }
        public virtual DbSet<quizz> quizz { get; set; }
        public virtual DbSet<reponse> reponse { get; set; }
        public virtual DbSet<reponse_candidat> reponse_candidat { get; set; }
        public virtual DbSet<taux_complexite> taux_complexite { get; set; }
    }
}
