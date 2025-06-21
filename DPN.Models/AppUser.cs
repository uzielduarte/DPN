using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPN.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength (50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [MaxLength (200)]
        public string Address { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
