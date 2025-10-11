namespace EventsDS.Models.Entities
{
    public class Events
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
        public ICollection<Event_Category> Event_Categories { get; set; } = new List<Event_Category>();
        public int StageId { get; set; }
        public Stage Stage { get; set; } = null!;

    }
}
