using EventsDS.Data;
using EventsDS.Models;
using EventsDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public StageController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStages()
        {
            var allStages = dbContext.Stages.ToList();
            return Ok(allStages);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStagesById(int id)
        {
            var Stages = dbContext.Stages.Find(id);

            if (Stages == null)
            {

                return NotFound();
            }

            return Ok(Stages);
        }

        [HttpPost]
        public IActionResult AddStage(AddStageDto addStageDto)
        {
            var Stagesentity = new Stage()
            {
                Name = addStageDto.Name,
                peoplecapacity = addStageDto.peoplecapacity,
                location = addStageDto.location,

            };

            dbContext.Stages.Add(Stagesentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Stage added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateStage(int id, UpdateStageDto updateStageDto)
        {
            var existingStage = dbContext.Stages.Find(id);
            if (existingStage == null)
            {
                return NotFound();
            }

            existingStage.Name = updateStageDto.Name;
            existingStage.peoplecapacity = updateStageDto.peoplecapacity;
            existingStage.location = updateStageDto.location;


            dbContext.SaveChanges();
            return Ok(existingStage);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteStage(int id)
        {
            var existingStage = dbContext.Stages.Find(id);

            if (existingStage is null)
            {
                return NotFound();
            }
            dbContext.Stages.Remove(existingStage);
            dbContext.SaveChanges();

            return Ok();


        }

    }
}
