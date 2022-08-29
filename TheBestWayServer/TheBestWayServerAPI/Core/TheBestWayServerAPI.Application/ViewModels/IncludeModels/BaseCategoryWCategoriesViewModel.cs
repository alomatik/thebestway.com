using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.ViewModels.CategoryModels;

namespace TheBestWayServerAPI.Application.ViewModels.IncludeModels
{
    public class BaseCategoryWCategoriesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalCategoryCount { get; set; }

        public List<CategoryForBaseCategoryViewModel> Categories { get; set; }

    }
}
