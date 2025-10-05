using EventoDS.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventoDS.Models
{
    public class AddPrivilegesDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        // Relationship with Role_Privileges
        public ICollection<Roles_Privileges> Role_Privileges { get; set; } = new List<Roles_Privileges>();
    }
}
