using ProyectoEventosDS.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEeventosDS.Models
{
    public class AddUserDto
    {
        public string Name_user { get; set; } = null!;

        public string Email_user { get; set; } = null!;
      
        public bool Active { get; set; }

        public Role Role { get; set; } = null!;
    }
}
