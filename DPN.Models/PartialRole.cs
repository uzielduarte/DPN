using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPN.Models
{
    public class PartialRole
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string RoleDescription { get; set; }
    }
}
