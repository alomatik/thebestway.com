using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.ViewModels.RoleModels
{
    public class UserRoleViewModel
    {
        public int UserId { get; set; }
     
        public string[] Roles { get; set; }
    }
}
