using UserDS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace UserDS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Privilege> Privileges { get; set; } = null!;
        public DbSet<Roles_Privileges> Role_Privileges { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Indicar que el Id de Role se genera automáticamente
            modelBuilder.Entity<Role>()
                        .Property(r => r.Id)
                        .ValueGeneratedOnAdd();

            // Lo mismo para otras entidades con Id auto-incremental
            modelBuilder.Entity<User>()
                        .Property(u => u.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Privilege>()
                        .Property(p => p.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Roles_Privileges>()
                        .Property(rp => rp.Id)
                        .ValueGeneratedOnAdd();
        }
    }
}
