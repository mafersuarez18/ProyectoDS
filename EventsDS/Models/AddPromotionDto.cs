namespace EventsDS.Models
{
    public class AddPromotionDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Percentage { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int EventId { get; set; }
    }
}
