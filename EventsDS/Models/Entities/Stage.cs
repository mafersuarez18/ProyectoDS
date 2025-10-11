namespace EventsDS.Models.Entities
{
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int peoplecapacity { get; set; }
        public string location { get; set; }
        public ICollection<Events> Events { get; set; } = new List<Events>();
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();

    }
}
