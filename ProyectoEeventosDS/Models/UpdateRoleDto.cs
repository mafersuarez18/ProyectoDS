using ProyectoEventosDS.Models;

namespace ProyectoEeventosDS.Models
{
    public class UpdateRoleDto
    {
        public string Name_Role { get; set; } = null!;

        // Relationship with Privileges
        public ICollection<Privilege> Privileges { get; set; } = new List<Privilege>();

        // Relationship with Users
        public ICollection<User> Users { get; set; }
    }
}
