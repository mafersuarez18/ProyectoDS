using Microsoft.EntityFrameworkCore;
using PaymentsDS.Models.Entities;

namespace PaymentsDS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Bill> Bills { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación 1:1 entre Bill y Payment
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Payment)
                .WithOne(p => p.Bill)
                .HasForeignKey<Payment>(p => p.BillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
