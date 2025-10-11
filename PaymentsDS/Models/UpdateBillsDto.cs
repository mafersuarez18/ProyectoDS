using PaymentsDS.Models.Entities;

namespace PaymentsDS.Models
{
    public class UpdateBillsDto
    {
        public DateOnly date { get; set; }
        public int PaymentId { get; set; }
    }
}
