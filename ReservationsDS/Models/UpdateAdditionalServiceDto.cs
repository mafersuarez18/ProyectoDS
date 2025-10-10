using ReservationsDS.Models.Entities;

namespace ReservationsDS.Models
{
    public class UpdateAdditionalServiceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<Reservation_Service> Reservation_Service { get; set; } = new List<Reservation_Service>();
    }
}
