using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Principal.Models
{
    public partial class ModelData : DbContext
    {
        public ModelData() : base("name=Database")
        {}

        public virtual DbSet<Assign> Assigns { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {}
    }
}
