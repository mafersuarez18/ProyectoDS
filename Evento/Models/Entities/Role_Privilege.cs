using System.ComponentModel.DataAnnotations;

namespace ProyectoEventosDS.Models
{
    public class Role_Privilege
    {
        [Key]
        public int Id { get; set; }

        // Foreign key to Role
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        // Foreign key to Privilege
        public int PrivilegeId { get; set; }
        public Privilege Privilege { get; set; } = null!;
    }
}
