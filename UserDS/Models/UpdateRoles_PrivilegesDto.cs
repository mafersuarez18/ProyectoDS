using UserDS.Models.Entities;

namespace UserDS.Models
{
    public class UpdateRoles_PrivilegesDto
    {
        // Foreign key to Role
        public int RoleId { get; set; }

        // Foreign key to Privilege
        public int PrivilegeId { get; set; }       

    }
}
