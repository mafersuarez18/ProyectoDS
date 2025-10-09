using PaymentsDS.Models.Entities;

namespace PaymentsDS.Models
{
    public class UpdateBillsDto
    {
        public int Id { get; set; }
        public DateOnly date { get; set; }

        // Relación 1 a 1 con Payment
        public Payment Payment { get; set; }
    }
}
