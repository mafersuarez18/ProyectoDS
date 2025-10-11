using PaymentsDS.Models.Entities;

namespace PaymentsDS.Models
{
    public class AddBillsDto
    {
        public DateOnly date { get; set; }
        public int PaymentId { get; set; }

    }
}
