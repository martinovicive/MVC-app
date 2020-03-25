using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aplikacija.Models
{
    public class SeminarDbContext: DbContext
    {
        public SeminarDbContext()
           : base("connectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Seminar> Seminar { get; set; }
        public virtual DbSet<Predbiljezba> Predbiljezba { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }
    }
}