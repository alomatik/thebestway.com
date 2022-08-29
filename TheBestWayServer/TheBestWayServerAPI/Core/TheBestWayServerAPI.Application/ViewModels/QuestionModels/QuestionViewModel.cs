using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.ViewModels.QuestionAnswerModels;

namespace TheBestWayServerAPI.Application.ViewModels.QuestionModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }
        
        public DateTime? CreatedDate { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
