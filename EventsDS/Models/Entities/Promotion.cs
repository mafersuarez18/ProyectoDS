namespace EventsDS.Models.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Percentage { get; set; }
        public DateOnly StarDate { get; set; }
        public DateOnly EndDate { get;set; }
        public int EventId { get; set; }
        public Events Events { get; set; } = null!;

    }
}
