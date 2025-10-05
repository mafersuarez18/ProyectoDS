using EventoDS.Models.Entities;

namespace EventoDS.Models
{
    public class AddRoles_PrivilegesDto
    {
        // Foreign key to Role
        public int RoleId { get; set; }

        // Foreign key to Privilege
        public int PrivilegeId { get; set; }
        
    }
}
