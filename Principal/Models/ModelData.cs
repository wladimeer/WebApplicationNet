using System.Data.Entity;

namespace Principal.Models
{
    public partial class ModelData : DbContext
    {
        public ModelData() : base("name=ModelData")
        {}

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tool>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.Tool)
                .HasForeignKey(e => e.tool_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.Worker)
                .HasForeignKey(e => e.worker_id)
                .WillCascadeOnDelete(false);
        }
    }
}
