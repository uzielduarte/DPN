using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DPN.Models
{
    public class AppRole : IdentityRole
    {
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        public override string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string? RoleDescription { get; set; }
    }
}
