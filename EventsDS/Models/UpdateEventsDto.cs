using EventsDS.Models.Entities;

namespace EventsDS.Models
{
    public class UpdateEventsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }     
        public int StageId { get; set; }
    }
}
