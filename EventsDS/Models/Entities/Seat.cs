namespace EventsDS.Models.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string row_number { get; set; }
        public int seatnumber { get; set; }

        public string zone { get; set; }
        public int StageId { get; set; }
        public Stage Stage { get; set; } = null!;

    }
}
