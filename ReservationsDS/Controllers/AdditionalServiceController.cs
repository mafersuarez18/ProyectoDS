using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationsDS.Data;
using ReservationsDS.Models;
using ReservationsDS.Models.Entities;

namespace ReservationsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalServiceController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public AdditionalServiceController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllAdditionalServices()
        {
            var allAdditionalServices = dbContext.AdditionalServices.ToList();
            return Ok(allAdditionalServices);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAdditionalServiceById(int id)
        {
            var AdditionalService = dbContext.AdditionalServices.Find(id);

            if (AdditionalService == null)
            {

                return NotFound();
            }

            return Ok(AdditionalService);
        }

        [HttpPost]
        public IActionResult AddAdditionalService(AddAdditionalServiceDto addAdditionalServiceDto)
        {
            var AdditionalServiceentity = new AdditionalService()
            {
                Name = addAdditionalServiceDto.Name,
                Description = addAdditionalServiceDto.Description,
                Price = addAdditionalServiceDto.Price

            };

            dbContext.AdditionalServices.Add(AdditionalServiceentity);
            dbContext.SaveChanges();

            return Ok(new { message = "AdditionalService added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateAdditionalService(int id, UpdateAdditionalServiceDto updateAdditionalServiceDto)
        {
            var existingAdditionalService = dbContext.AdditionalServices.Find(id);
            if (existingAdditionalService == null)
            {
                return NotFound();
            }

           existingAdditionalService.Name = updateAdditionalServiceDto.Name;
           existingAdditionalService.Description = updateAdditionalServiceDto.Description;
           existingAdditionalService.Price = updateAdditionalServiceDto.Price;


            dbContext.SaveChanges();
            return Ok(existingAdditionalService);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteAdditionalService(int id)
        {
            var existingAdditionalService = dbContext.AdditionalServices.Find(id);

            if (existingAdditionalService is null)
            {
                return NotFound();
            }
            dbContext.AdditionalServices.Remove(existingAdditionalService);
            dbContext.SaveChanges();

            return Ok();


        }

    }
}

