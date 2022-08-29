using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Domain.Common;

namespace TheBestWayServerAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public int BaseCategoryId { get; set; }

        public BaseCategory BaseCategory { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
