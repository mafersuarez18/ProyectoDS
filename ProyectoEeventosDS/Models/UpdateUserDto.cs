using ProyectoEventosDS.Models;

namespace ProyectoEeventosDS.Models
{
    public class UpdateUserDto
    {
        public string Name_user { get; set; } = null!;

        public string Email_user { get; set; } = null!;

        public bool Active { get; set; }

        // Foreign key to Role
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
