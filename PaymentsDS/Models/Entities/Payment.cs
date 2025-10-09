namespace PaymentsDS.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateOnly date { get; set; }
        public double amount { get; set; }
        public string state { get; set; }

        // Clave foránea hacia Bill
        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}
