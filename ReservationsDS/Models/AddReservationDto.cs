using ReservationsDS.Models.Entities;

namespace ReservationsDS.Models
{
    public class AddReservationDto
    {
        public DateOnly Date { get; set; }
        public string State { get; set; }
    }
}
