using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Domain.Common;

namespace TheBestWayServerAPI.Domain.Entities
{
    public class PostDetail:BaseEntity
    {
        public int ViewCount { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        public int PostId { get; set; }
        
        public Post Post { get; set; }
    }
}
