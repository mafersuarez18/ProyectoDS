namespace PaymentsDS.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateOnly date { get; set; }
        public double amount { get; set; }
        public string state { get; set; }

        // Relación 1:1 con Bill
        public Bill Bill { get; set; }
    }
}
