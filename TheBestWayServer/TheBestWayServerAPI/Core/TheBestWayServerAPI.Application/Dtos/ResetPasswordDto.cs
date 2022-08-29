﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.Dtos
{
    public class ResetPasswordDto
    {
        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string NewPasswordConfirm { get; set; }

    }
}
