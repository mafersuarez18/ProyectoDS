using System.ComponentModel.DataAnnotations;

namespace ProyectoEventosDS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } = null!;

        [Required]
        public bool Active { get; set; }

        // Foreign key to Role
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
