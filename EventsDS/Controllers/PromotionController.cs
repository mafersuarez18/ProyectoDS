using EventsDS.Data;
using EventsDS.Models;
using EventsDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PromotionController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPromotions()
        {
            var allPromotions = dbContext.Promotion.ToList();
            return Ok(allPromotions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPromotionById(int id)
        {
            var Promotion = dbContext.Promotion.Find(id);

            if (Promotion == null)
            {

                return NotFound();
            }

            return Ok(Promotion);
        }

        [HttpPost]
        public IActionResult AddPromotion(AddPromotionDto addPromotionDto)
        {
            var Promotionentity = new Promotion()
            {
                Code = addPromotionDto.Code,
                Description = addPromotionDto.Description,
                Percentage = addPromotionDto.Percentage,
                StartDate = addPromotionDto.StartDate,
                EndDate = addPromotionDto.EndDate,
                EventId = addPromotionDto.EventId,
            };

            dbContext.Promotion.Add(Promotionentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Promotion added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdatePromotion(int id, UpdatePromotionDto updatePromotionDto)
        {
            var existingPromotion = dbContext.Promotion.Find(id);
            if (existingPromotion == null)
            {
                return NotFound();
            }

            existingPromotion.Code = updatePromotionDto.Code;
            existingPromotion.Description = updatePromotionDto.Description;
            existingPromotion.Percentage = updatePromotionDto.Percentage;
            existingPromotion.StartDate = updatePromotionDto.StartDate;
            existingPromotion.EndDate = updatePromotionDto.EndDate;
            existingPromotion.EventId = updatePromotionDto.EventId;


            dbContext.SaveChanges();
            return Ok(existingPromotion);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletePromotion(int id)
        {
            var existingPromotion = dbContext.Promotion.Find(id);

            if (existingPromotion is null)
            {
                return NotFound();
            }
            dbContext.Promotion.Remove(existingPromotion);
            dbContext.SaveChanges();

            return Ok();


        }
    }
}
