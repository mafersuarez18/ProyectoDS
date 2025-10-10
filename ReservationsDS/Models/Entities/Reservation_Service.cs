using System.ComponentModel.DataAnnotations;

namespace ReservationsDS.Models.Entities
{
    public class Reservation_Service
    {
        [Key]
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation? Reservation{ get; set; } = null!;
        public int ServiceId { get; set; }
        public AdditionalService? AdditionalService { get; set; } = null!;
    }
}
