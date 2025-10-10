using Microsoft.EntityFrameworkCore;
using ReservationsDS.Models.Entities;

namespace ReservationsDS.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<AdditionalService> AdditionalServices { get; set; } = null!;
        public DbSet<Reservation_Service> Reservation_Services { get; set; } = null!;
    }
}
