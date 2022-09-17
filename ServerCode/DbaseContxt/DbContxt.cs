using Microsoft.EntityFrameworkCore;
using ServerCode.Model;

namespace ServerCode.DbaseContxt
{
    public class DbContxt : DbContext
    {
        public DbContxt(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> projects { get; set; }
        public DbSet<Taask> tasks { get; set; }
        //public DbSet<User> users { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Project>()
        //    .HasMany(b => b.Taasks)
        //    .WithOne();

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taask>().Ignore(m => m.Project);
            base.OnModelCreating(modelBuilder);
        }
    }
}
