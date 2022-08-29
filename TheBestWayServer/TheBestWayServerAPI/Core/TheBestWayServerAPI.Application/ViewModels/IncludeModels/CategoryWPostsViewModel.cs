using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.ViewModels.PostModels;

namespace TheBestWayServerAPI.Application.ViewModels.IncludeModels
{
    public class CategoryWPostsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BaseCategoryId { get; set; }

        public List<PostForCategoryViewModel> Posts { get; set; }
    }
}
