using ProyectoEeventosDS.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEventosDS.Models
{
    public class Privilege
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        // Relationship with Role_Privileges
        public ICollection<Role_Privilege> Role_Privileges { get; set; } = new List<Role_Privilege>();
    }
}
