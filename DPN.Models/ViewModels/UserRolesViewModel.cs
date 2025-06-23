using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPN.Models.ViewModels
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
        public List<AppRole> AllRoles { get; set; } = new();
    }
}
