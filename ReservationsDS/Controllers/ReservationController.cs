using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationsDS.Data;
using ReservationsDS.Models;
using ReservationsDS.Models.Entities;

namespace ReservationsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ReservationController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            var allReservations = dbContext.Reservations.ToList();
            return Ok(allReservations);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetReservationsById(int id)
        {
            var Reservation = dbContext.Reservations.Find(id);

            if (Reservation == null)
            {

                return NotFound();
            }

            return Ok(Reservation);
        }

        [HttpPost]
        public IActionResult AddReservation(AddReservationDto addReservationDto)
        {
            var Reservationsentity = new Reservation()
            {
                Date = addReservationDto.Date,
                State = addReservationDto.State,
            };

            dbContext.Reservations.Add(Reservationsentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Reservations added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateReservations(int id, UpdateReservationDto updateReservationsDto)
        {
            var existingReservation = dbContext.Reservations.Find(id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            existingReservation.Date = updateReservationsDto.Date;
            existingReservation.State = updateReservationsDto.State;
            dbContext.SaveChanges();
            return Ok(existingReservation);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteReservations(int id)
        {
            var existingReservation = dbContext.Reservations.Find(id);

            if (existingReservation is null)
            {
                return NotFound();
            }
            dbContext.Reservations.Remove(existingReservation);
            dbContext.SaveChanges();

            return Ok();


        }

    }

}

