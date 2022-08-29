using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Domain.Common;

namespace TheBestWayServerAPI.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string? ImagePath { get; set; }

        public bool IsDeleted { get; set; }

        public PostDetail PostDetail { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
