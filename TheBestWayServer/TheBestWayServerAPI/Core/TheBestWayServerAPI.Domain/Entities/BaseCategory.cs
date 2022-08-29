using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Domain.Common;

namespace TheBestWayServerAPI.Domain.Entities
{
    public class BaseCategory: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
