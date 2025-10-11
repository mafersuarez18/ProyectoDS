namespace PaymentsDS.Models.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public DateOnly date { get; set; }

        // Clave foránea de Payment
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
