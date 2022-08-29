using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.Update
{
    public class UpdateUserCommandRequest:IRequest<CommandNoMessageResult>
    {
        public int Id { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? ThumbnailFormFile { get; set; }

        public string? ThumbnailPath { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Profession { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? TwitterLink { get; set; }

        public string? GitHubLink { get; set; }

        public string? YouTubeLink { get; set; }

        public string? InstagramLink { get; set; }
    }
}
