using EventsDS.Data;
using EventsDS.Models;
using EventsDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Event_CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public Event_CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEvents_Category()
        {
            var allEvents_Category = dbContext.Events_Category.ToList();
            return Ok(allEvents_Category);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEvent_CategoryById(int id)
        {
            var Event_Category = dbContext.Events_Category.Find(id);

            if (Event_Category == null)
            {

                return NotFound();
            }

            return Ok(Event_Category);
        }

        [HttpPost]
        public IActionResult AddEvent_Category(AddEvent_CategoryDto addEvent_CategoryDto)
        {
            var Event_Categoryentity = new Event_Category()
            {
                CategoryId = addEvent_CategoryDto.CategoryId,
                EventId = addEvent_CategoryDto.EventId,

            };

            dbContext.Events_Category.Add(Event_Categoryentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Event_Category added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEvent_Category(int id, UpdateEvent_CategoryDto updateEvent_CategoryDto)
        {
            var existingEvent_Category = dbContext.Events_Category.Find(id);
            if (existingEvent_Category == null)
            {
                return NotFound();
            }

            existingEvent_Category.CategoryId = updateEvent_CategoryDto.CategoryId;
            existingEvent_Category.EventId = updateEvent_CategoryDto.EventId;


            dbContext.SaveChanges();
            return Ok(existingEvent_Category);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEvent_Category(int id)
        {
            var existingEvent_Category = dbContext.Events_Category.Find(id);

            if (existingEvent_Category is null)
            {
                return NotFound();
            }
            dbContext.Events_Category.Remove(existingEvent_Category);
            dbContext.SaveChanges();

            return Ok();


        }

    }
}
