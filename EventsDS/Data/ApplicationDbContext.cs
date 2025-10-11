using EventsDS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsDS.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        DbSet<Category> Categories { get; set; } = null!;
        DbSet<Event_Category> Events_Category { get; set; } = null!;
        DbSet<Events> Events { get; set; } = null!;
        DbSet<Promotion> Promotion { get; set; } = null!;
        DbSet<Seat> Sits { get; set; } = null!;
        DbSet<Stage> Stages { get; set; } = null!;


    }
}
