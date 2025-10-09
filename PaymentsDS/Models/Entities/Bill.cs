namespace PaymentsDS.Models.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public DateOnly date { get; set; }

        // Relación 1 a 1 con Payment
        public Payment Payment { get; set; }
    }
}
