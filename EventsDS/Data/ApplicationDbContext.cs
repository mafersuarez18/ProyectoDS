using EventsDS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsDS.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

       public DbSet<Category> Categories { get; set; } = null!;
       public DbSet<Event_Category> Events_Category { get; set; } = null!;
       public DbSet<Events> Events { get; set; } = null!;
       public DbSet<Promotion> Promotion { get; set; } = null!;
       public DbSet<Seat> Seats { get; set; } = null!;
       public DbSet<Stage> Stages { get; set; } = null!;


    }
}
