using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoEeventosDS.Models;
using ProyectoEventosDS.Data;
using ProyectoEventosDS.Models;

namespace ProyectoEeventosDS.Controllers
{
    //localhost:xxxx/api/users
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = dbContext.Users.ToList();
            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetUsersById(int id) 
        {
            var user = dbContext.Users.Find(id);

            if (user == null)
            {

                return NotFound();
            }
            
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity = new User()
            {
                Name_user = addUserDto.Name_user,
                Email_user = addUserDto.Email_user,
                Active = addUserDto.Active,
                RoleId = addUserDto.RoleId
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(new { message = "User added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var existingUser = dbContext.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Name_user = updateUserDto.Name_user;
            existingUser.Email_user = updateUserDto.Email_user;
            existingUser.Active = updateUserDto.Active;
            existingUser.RoleId = updateUserDto.RoleId;
            
            dbContext.SaveChanges();
            return Ok(existingUser);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var existinguser = dbContext.Users.Find(id);

          if (existinguser is null)
          {
                return NotFound();  
          }
            dbContext.Users.Remove(existinguser);
            dbContext.SaveChanges();

            return Ok();


        }


    }
}
