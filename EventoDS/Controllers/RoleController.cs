using EventoDS.Data;
using EventoDS.Models;
using EventoDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public RoleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var allRoles = dbContext.Roles.ToList();
            return Ok(allRoles);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetRoleById(int id)
        {
            var Role = dbContext.Roles.Find(id);

            if (Role == null)
            {

                return NotFound();
            }

            return Ok(Role);
        }

        [HttpPost]
        public IActionResult AddRole(AddRoleDto addroleDto)
        {
            var rolesentity = new Role()
            {
                Name = addroleDto.Name,
                Description = addroleDto.Description
            };

            dbContext.Roles.Add(rolesentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Role added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateRoles(int id, UpdateRoleDto updateRoleDto)
        {
            var existingRole = dbContext.Roles.Find(id);
            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name = updateRoleDto.Name;
            existingRole.Description = updateRoleDto.Description;

            dbContext.SaveChanges();
            return Ok(existingRole);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRoles(int id)
        {
            var existingRole = dbContext.Roles.Find(id);

            if (existingRole is null)
            {
                return NotFound();
            }
            dbContext.Roles.Remove(existingRole);
            dbContext.SaveChanges();

            return Ok();


        }

    }



}

