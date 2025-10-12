using EventsDS.Data;
using EventsDS.Models;
using EventsDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SeatController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllSeats()
        {
            var allSeats = dbContext.Seats.ToList();
            return Ok(allSeats);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSeatById(int id)
        {
            var Seat = dbContext.Seats.Find(id);

            if (Seat == null)
            {

                return NotFound();
            }

            return Ok(Seat);
        }

        [HttpPost]
        public IActionResult AddSeat(AddSeatDto addSeatDto)
        {
            var Seatentity = new Seat()
            {
                row_number = addSeatDto.row_number,
                seatnumber = addSeatDto.seatnumber,
                zone = addSeatDto.zone,
                StageId = addSeatDto.StageId,

            };

            dbContext.Seats.Add(Seatentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Seat added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateSeat(int id, UpdateSeatDto updateSeatDto)
        {
            var existingSeat = dbContext.Seats.Find(id);
            if (existingSeat == null)
            {
                return NotFound();
            }

            existingSeat.row_number = updateSeatDto.row_number; 
            existingSeat.zone = updateSeatDto.zone;
            existingSeat.StageId = updateSeatDto.StageId;
            existingSeat.seatnumber = updateSeatDto.seatnumber;

            dbContext.SaveChanges();
            return Ok(existingSeat);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteSeat(int id)
        {
            var existingSeat = dbContext.Seats.Find(id);

            if (existingSeat is null)
            {
                return NotFound();
            }
            dbContext.Seats.Remove(existingSeat);
            dbContext.SaveChanges();

            return Ok();


        }
    }
}
