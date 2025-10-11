namespace ReservationsDS.Models.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string State { get; set; }
        public ICollection<Reservation_Service> Reservation_Service { get; set; } = new List<Reservation_Service>();

    }
}
