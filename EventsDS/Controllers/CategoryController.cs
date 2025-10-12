using EventsDS.Data;
using EventsDS.Models;
using EventsDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var allCategories = dbContext.Categories.ToList();
            return Ok(allCategories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCategoryById(int id)
        {
            var Category = dbContext.Categories.Find(id);

            if (Category == null)
            {

                return NotFound();
            }

            return Ok(Category);
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryDto addCategoryDto)
        {
            var Categoryentity = new Category()
            {
                Name = addCategoryDto.Name,
                Description = addCategoryDto.Description

            };

            dbContext.Categories.Add(Categoryentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Category added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var existingCategory = dbContext.Categories.Find(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = updateCategoryDto.Name;
            existingCategory.Description = updateCategoryDto.Description;


            dbContext.SaveChanges();
            return Ok(existingCategory);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingCategory = dbContext.Categories.Find(id);

            if (existingCategory is null)
            {
                return NotFound();
            }
            dbContext.Categories.Remove(existingCategory);
            dbContext.SaveChanges();

            return Ok();


        }

    }
}
