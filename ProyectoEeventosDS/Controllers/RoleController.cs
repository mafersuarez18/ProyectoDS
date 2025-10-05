using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoEeventosDS.Models;
using ProyectoEventosDS.Data;
using ProyectoEventosDS.Models;

namespace ProyectoEeventosDS.Controllers
{
    //localhost:xxxx/api/role
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
        public IActionResult GetRolesById(int id)
        {
            var role = dbContext.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public IActionResult AddRole(AddRoleDto addRoleDto)
        {
            var roleEntity = new Role()
            {
                Name_Role = addRoleDto.Name_Role,
                
            };

            dbContext.Roles.Add(roleEntity);
            dbContext.SaveChanges();

            return Ok(new { message = "Role added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateRole(int id, UpdateRoleDto updateRoleDto)
        {
            var existingRole = dbContext.Roles.Find(id);
            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name_Role = updateRoleDto.Name_Role;
          

            dbContext.SaveChanges();
            return Ok(existingRole);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRole(int id)
        {
            var existingrole = dbContext.Roles.Find(id);

            if (existingrole is null)
            {
                return NotFound();
            }
            dbContext.Roles.Remove(existingrole);
            dbContext.SaveChanges();

            return Ok();
        }



    }
    }
