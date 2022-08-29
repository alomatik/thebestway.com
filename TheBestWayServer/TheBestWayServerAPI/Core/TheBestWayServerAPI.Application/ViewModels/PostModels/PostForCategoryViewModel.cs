using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.ViewModels.PostModels
{
    public class PostForCategoryViewModel
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int CategoryId { get; set; }
    }
}
