using UserDS.Data;
using UserDS.Models;
using UserDS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserDS.Controllers
    {
        //localhost:xxxx/api/user
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
            public IActionResult GetUserById(int id)
            {
                var User = dbContext.Users.Find(id);

                if (User == null)
                {

                    return NotFound();
                }

                return Ok(User);
            }

            [HttpPost]
            public IActionResult AddUsers(AddUserDto addusersDto)
            {
                var usersentity = new User()
                {
                    Name = addusersDto.Name,
                    Email = addusersDto.Email,
                    Active = addusersDto.Active,
                    RoleId = addusersDto.RoleId

                };

                dbContext.Users.Add(usersentity);
                dbContext.SaveChanges();

                return Ok(new { message = "User added successfully" });

            }

            [HttpPut]
            [Route("{id:int}")]
            public IActionResult UpdateUsers(int id, UpdateUserDto updateUserDto)
            {
                var existingUser = dbContext.Users.Find(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

            existingUser.Name = updateUserDto.Name;
            existingUser.Email = updateUserDto.Email;
            existingUser.Active = updateUserDto.Active;
            existingUser.RoleId = updateUserDto.RoleId;

            dbContext.SaveChanges();
                return Ok(existingUser);
            }

            [HttpDelete]
            [Route("{id:int}")]
            public IActionResult DeleteUsers(int id)
            {
                var existingUser = dbContext.Users.Find(id);

                if (existingUser is null)
                {
                    return NotFound();
                }
                dbContext.Users.Remove(existingUser);
                dbContext.SaveChanges();

                return Ok();


            }

        }
    }



