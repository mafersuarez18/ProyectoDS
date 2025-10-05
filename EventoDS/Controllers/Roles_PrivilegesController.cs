using EventoDS.Data;
using EventoDS.Models;
using EventoDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoDS.Controllers
{
    //localhost:xxxx/api/roles_privileges
    [Route("api/[controller]")]
    [ApiController]
    public class Roles_PrivilegesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public Roles_PrivilegesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllRoles_Privileges()
        {
            var allRoles_Privileges = dbContext.Role_Privileges.ToList();
            return Ok(allRoles_Privileges);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetRoles_PrivilegesById(int id)
        {
            var Role_Privileges = dbContext.Role_Privileges.Find(id);

            if (Role_Privileges == null)
            {

                return NotFound();
            }

            return Ok(Role_Privileges);
        }

        [HttpPost]
        public IActionResult AddRole_Privileges(AddRoles_PrivilegesDto dto)
        {
            // Verificar si la relación ya existe
            var exists = dbContext.Role_Privileges
                .Any(rp => rp.RoleId == dto.RoleId && rp.PrivilegeId == dto.PrivilegeId);

            if (exists)
                return BadRequest(new { message = "Esta relación ya existe" });

            var entity = new Roles_Privileges
            {
                RoleId = dto.RoleId,
                PrivilegeId = dto.PrivilegeId
            };

            dbContext.Role_Privileges.Add(entity);
            dbContext.SaveChanges();

            return Ok(new { message = "Role_Privilege added successfully" });
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateRoles_Privileges(int id, UpdateRoles_PrivilegesDto updateRoles_PrivilegesDto)
        {
            var existingRole_Privilege = dbContext.Role_Privileges.Find(id);
            if (existingRole_Privilege == null)
            {
                return NotFound();
            }
            
            existingRole_Privilege .RoleId = updateRoles_PrivilegesDto.RoleId; ;
            existingRole_Privilege .PrivilegeId = updateRoles_PrivilegesDto.PrivilegeId;

            dbContext.SaveChanges();
            return Ok(existingRole_Privilege);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRoles_Privileges(int id)
        {
            var existingRole_Privilege = dbContext.Role_Privileges.Find(id);

            if (existingRole_Privilege is null)
            {
                return NotFound();
            }
            dbContext.Role_Privileges.Remove(existingRole_Privilege);
            dbContext.SaveChanges();

            return Ok();


        }
    }
}
