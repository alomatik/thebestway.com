using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.ViewModels.CommentModels
{
    public class CommentForUserViewModel
    {
        public int? UserId { get; set; }

        public int Id { get; set; }

        public string? Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? PostId { get; set; }

        public string PostTitle { get; set; }
    }
}
