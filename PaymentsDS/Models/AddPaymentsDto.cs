using PaymentsDS.Models.Entities;

namespace PaymentsDS.Models
{
    public class AddPaymentsDto    {
        
        public DateOnly date { get; set; }
        public double amount { get; set; }
        public string state { get; set; }                
        
    }
}
