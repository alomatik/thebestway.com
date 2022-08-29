using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.ViewModels.UserModels
{
    public class UserViewModel
    {
        public string? ThumbnailPath { get; set; }

        public string UserName { get; set; }

        public string? Profession { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? TwitterLink { get; set; }

        public string? GitHubLink { get; set; }

        public string? YouTubeLink { get; set; }

        public string? InstagramLink { get; set; }

    }
}
