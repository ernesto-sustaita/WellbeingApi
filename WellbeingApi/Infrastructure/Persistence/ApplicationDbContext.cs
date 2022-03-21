using Domain.Entities;
using System.Data.Entity;

namespace Infrastructure
{
    public partial class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Alert> Alert { get; set; }
    }
}