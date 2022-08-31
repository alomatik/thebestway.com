using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.ViewModels.RoleModels
{
    public class AssignRoleViewModel
    {
        public int Id { get; set; }
        
        public string RoleName { get; set; }

        public bool HasRole { get; set; }
    }
}
