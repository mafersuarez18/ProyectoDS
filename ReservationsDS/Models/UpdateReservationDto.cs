using ReservationsDS.Models.Entities;

namespace ReservationsDS.Models
{
    public class UpdateReservationDto
    {
        public DateOnly Date { get; set; }
        public string State { get; set; }
        
    }
}
