using Microsoft.EntityFrameworkCore;
using ProyectoEventosDS.Models;

namespace ProyectoEventosDS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Privilege> Privileges { get; set; } = null!;
        public DbSet<Role_Privilege> Role_Privileges { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Role
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Active).IsRequired();

                entity.HasOne(u => u.Role)
                      .WithMany(r => r.Users)
                      .HasForeignKey(u => u.RoleId);
            });

            // Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            // Privilege
            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Role_Privilege (Many-to-Many explicit)
            modelBuilder.Entity<Role_Privilege>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(rp => rp.Role)
                      .WithMany(r => r.Role_Privileges)
                      .HasForeignKey(rp => rp.RoleId);

                entity.HasOne(rp => rp.Privilege)
                      .WithMany(p => p.Role_Privileges)
                      .HasForeignKey(rp => rp.PrivilegeId);
            });
        }
    }
}
