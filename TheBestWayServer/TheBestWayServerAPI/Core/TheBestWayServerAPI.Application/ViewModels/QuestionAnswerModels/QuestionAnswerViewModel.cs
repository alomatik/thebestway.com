using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.ViewModels.QuestionAnswerModels
{
    public class QuestionAnswerViewModel
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int QuestionId { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }
    }
}
