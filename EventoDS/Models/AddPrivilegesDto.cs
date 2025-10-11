using UserDS.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace UserDS.Models
{
    public class AddPrivilegesDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
