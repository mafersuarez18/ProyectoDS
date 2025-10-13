using System.ComponentModel.DataAnnotations;

namespace EventsDS.Models.Entities
{
    public class Event_Category
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int EventId { get; set; }
        public Events Events { get; set; } = null!;
    }
}
