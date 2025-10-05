using EventoDS.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventoDS.Models
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
