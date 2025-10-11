using UserDS.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace UserDS.Models
{
    public class AddUserDto
    {
        public string Name { get; set; } 

        public string Email { get; set; } 

        public bool Active { get; set; }

        // Foreign key to Role
        public int RoleId { get; set; }        
    }
}
