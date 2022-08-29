using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayShared.SharedForWorkerService.Dtos
{
    public class MailandResetPasswordUrlDto
    {
        public string Mail { get; set; }
        
        public string PasswordResetUrl { get; set; }
    }
}
