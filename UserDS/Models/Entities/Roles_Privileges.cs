using System.ComponentModel.DataAnnotations;

namespace UserDS.Models.Entities
{
    public class Roles_Privileges
    {
        [Key]
        public int Id { get; set; }

        // Foreign key to Role
        public int RoleId { get; set; }
        public Role? Role { get; set; } = null!;

        // Foreign key to Privilege
        public int PrivilegeId { get; set; }
        public Privilege? Privilege { get; set; } = null!;
    }
}
