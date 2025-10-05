using ProyectoEeventosDS.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEventosDS.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        // Relationship with Users
        public ICollection<User> Users { get; set; } = new List<User>();

        // Relationship with Role_Privileges
        public ICollection<Role_Privilege> Role_Privileges { get; set; } = new List<Role_Privilege>();
    }
}
