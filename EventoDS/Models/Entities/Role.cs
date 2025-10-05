using System.ComponentModel.DataAnnotations;

namespace EventoDS.Models.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        // Relationship with Users
        public ICollection<User> Users { get; set; } = new List<User>();

        // Relationship with Role_Privileges
        public ICollection<Roles_Privileges> Role_Privileges { get; set; } = new List<Roles_Privileges>();
    }
}
