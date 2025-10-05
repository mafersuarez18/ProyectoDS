using EventoDS.Data;
using EventoDS.Models;
using EventoDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoDS.Controllers
{
    //localhost:xxxx/api/privilege
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PrivilegeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPrivileges()
        {
            var allPrivileges = dbContext.Privileges.ToList();
            return Ok(allPrivileges);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPrivilegesById(int id)
        {
            var Privilege = dbContext.Privileges.Find(id);

            if (Privilege == null)
            {

                return NotFound();
            }

            return Ok(Privilege);
        }

        [HttpPost]
        public IActionResult AddPrivileges(AddPrivilegesDto addprivilegesDto)
        {
            var privilegesentity = new Privilege()
            {
                Name = addprivilegesDto.Name,
                Description = addprivilegesDto.Description
            };

            dbContext.Privileges.Add(privilegesentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Privilege added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdatePrivileges(int id, UpdatePrivilegesDto updatePrivilegesDto)
        {
            var existingPrivilege = dbContext.Privileges.Find(id);
            if (existingPrivilege == null)
            {
                return NotFound();
            }
            existingPrivilege.Name = updatePrivilegesDto.Name;
            existingPrivilege.Description = updatePrivilegesDto.Description;

            dbContext.SaveChanges();
            return Ok(existingPrivilege);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletePrivileges(int id)
        {
            var existingPrivilege = dbContext.Privileges.Find(id);

            if (existingPrivilege is null)
            {
                return NotFound();
            }
            dbContext.Privileges.Remove(existingPrivilege);
            dbContext.SaveChanges();

            return Ok();


        }

    }
}
