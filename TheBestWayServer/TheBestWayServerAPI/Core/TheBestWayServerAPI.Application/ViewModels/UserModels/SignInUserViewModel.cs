using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.ViewModels.UserModels
{
    public class SignInUserViewModel
    {
        [Required]
        public string UserNameorEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
