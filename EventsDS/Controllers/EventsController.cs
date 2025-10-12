using EventsDS.Data;
using EventsDS.Models;
using EventsDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EventsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var allEvents = dbContext.Events.ToList();
            return Ok(allEvents);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEventsById(int id)
        {
            var Events = dbContext.Events.Find(id);

            if (Events == null)
            {

                return NotFound();
            }

            return Ok(Events);
        }

        [HttpPost]
        public IActionResult AddEvents(AddEventsDto addEventsDto)
        {
            var Eventsentity = new Events()
            {
               Name = addEventsDto.Name,
               Description = addEventsDto.Description,
               Date = addEventsDto.Date,
               StageId = addEventsDto.StageId,

            };

            dbContext.Events.Add(Eventsentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Event added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEvents(int id, UpdateEventsDto updateEventsDto)
        {
            var existingEvent = dbContext.Events.Find(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            existingEvent.Name = updateEventsDto.Name;
            existingEvent.Description = updateEventsDto.Description;
            existingEvent.Date = updateEventsDto.Date;
            existingEvent.StageId = updateEventsDto.StageId;
            

            dbContext.SaveChanges();
            return Ok(existingEvent);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEvent(int id)
        {
            var existingEvent = dbContext.Events.Find(id);

            if (existingEvent is null)
            {
                return NotFound();
            }
            dbContext.Events.Remove(existingEvent);
            dbContext.SaveChanges();

            return Ok();


        }

    }

}


    