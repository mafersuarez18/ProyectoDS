using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationsDS.Data;
using ReservationsDS.Models;
using ReservationsDS.Models.Entities;

namespace ReservationsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Reservation_ServiceController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public Reservation_ServiceController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllReservation_Services()
        {
            var allReservation_Services = dbContext.Reservation_Services.ToList();
            return Ok(allReservation_Services);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetByIdReservation_Services(int id)
        {
            var Reservation_Services = dbContext.Reservation_Services.Find(id);

            if (Reservation_Services == null)
            {

                return NotFound();
            }

            return Ok(Reservation_Services);
        }

        [HttpPost]
        public IActionResult AddReservation_Services(AddReservation_ServiceDto dto)
        {
            // Verificar si la relación ya existe
            var exists = dbContext.Reservation_Services
                .Any(rp => rp.ReservationId == dto.ReservationId && rp.ServiceId == dto.ServiceId);

            if (exists)
                return BadRequest(new { message = "Esta relación ya existe" });

            var entity = new Reservation_Service
            {
                ReservationId = dto.ReservationId,
                ServiceId = dto.ServiceId
            };

            dbContext.Reservation_Services.Add(entity);
            dbContext.SaveChanges();

            return Ok(new { message = "Reservation_Services added successfully" });
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateReservation_Services(int id, UpdateReservation_ServiceDto updateReservation_ServiceDto)
        {
            var existingReservation_Services = dbContext.Reservation_Services.Find(id);
            if (existingReservation_Services == null)
            {
                return NotFound();
            }

            existingReservation_Services.ReservationId = updateReservation_ServiceDto.ReservationId; ;
            existingReservation_Services.ServiceId = updateReservation_ServiceDto.ServiceId;

            dbContext.SaveChanges();
            return Ok(existingReservation_Services);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteReservation_Services(int id)
        {
            var existingReservation_Services = dbContext.Reservation_Services.Find(id);

            if (existingReservation_Services is null)
            {
                return NotFound();
            }
            dbContext.Reservation_Services.Remove(existingReservation_Services);
            dbContext.SaveChanges();

            return Ok();


        }
    }
}
    