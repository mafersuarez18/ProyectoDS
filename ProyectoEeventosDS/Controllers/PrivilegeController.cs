using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEeventosDS.Models;
using ProyectoEventosDS.Data;
using ProyectoEventosDS.Models;

namespace ProyectoEeventosDS.Controllers
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
        var privilege = dbContext.Privileges.Find(id);

            if (privilege == null)
            {

                return NotFound();
            }

            return Ok(privilege);
        }


    [HttpPost]
    public IActionResult AddPrivilege(AddPrivilegeDto addPrivilegeDto)
    {
        var privilegeEntity = new Privilege()
          {
            Name_Privilege = addPrivilegeDto.Name_Privilege,
            
        };

            dbContext.Privileges.Add(privilegeEntity);
            dbContext.SaveChanges();

            return Ok(new { message = "User added successfully" });

        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdatePrivilege(int id, UpdatePrivilegeDto updatePrivilegeDto)
            {
            var existingprivilege = dbContext.Privileges.Find(id);
            if (existingprivilege == null)
            {
                return NotFound();
            }
            
            existingprivilege.Name_Privilege = updatePrivilegeDto.Name_Privilege;
            dbContext.SaveChanges();
            return Ok(new { message = "Privilege updated successfully" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletePrivilege(int id)
        {
            var existingprivilege = dbContext.Privileges.Find(id);

            if (existingprivilege is null)
            {
                return NotFound();
            }
            dbContext.Privileges.Remove(existingprivilege);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
  