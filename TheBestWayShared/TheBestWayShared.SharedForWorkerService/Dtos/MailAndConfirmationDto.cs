using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayShared.SharedForWorkerService.Dtos
{
    public class MailAndConfirmationDto
    {
        public string Mail { get; set; }

        public string EmailConfirmationUrl { get; set; }
    }
}
