using EventoDS.Models.Entities;

namespace EventoDS.Models
{
    public class AddRoleDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        // Relationship with Users
        public ICollection<User> Users { get; set; } = new List<User>();

        // Relationship with Role_Privileges
        public ICollection<Roles_Privileges> Role_Privileges { get; set; } = new List<Roles_Privileges>();
    }
}
