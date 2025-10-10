using ReservationsDS.Models.Entities;

namespace ReservationsDS.Models
{
    public class AddReservationDto
    {
        public DateOnly Date { get; set; }
        public ICollection<Reservation_Service> Reservation_Service { get; set; } = new List<Reservation_Service>();
    }
}
