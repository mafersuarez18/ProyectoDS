namespace EventsDS.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Event_Category> Event_Category { get; set; } = new List<Event_Category>();

    }
}
