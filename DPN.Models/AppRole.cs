using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DPN.Models
{
    public class AppRole : IdentityRole
    {
        [MaxLength(250)]
        public string? RoleDescription { get; set; }
    }
}
