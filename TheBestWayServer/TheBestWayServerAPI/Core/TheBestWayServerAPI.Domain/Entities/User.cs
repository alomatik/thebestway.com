using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Domain.Entities
{
    public class User:IdentityUser<int>
    {
        public string? ThumbnailPath { get; set; }

        public string? Profession { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? TwitterLink { get; set; }

        public string? GitHubLink { get; set; }

        public string? YouTubeLink { get; set; }

        public string? InstagramLink { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpirationDate { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        
        public IEnumerable<Question> Questions { get; set; }
    }
}
