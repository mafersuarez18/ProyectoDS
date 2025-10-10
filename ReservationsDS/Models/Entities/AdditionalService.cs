namespace ReservationsDS.Models.Entities
{
    public class AdditionalService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<Reservation_Service> Reservation_Service { get; set; } = new List<Reservation_Service>();

    }
}
