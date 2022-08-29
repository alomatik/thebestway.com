using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.PostCommand.Create
{
    public class CreatePostCommandRequest : IRequest<CommandWithMessageResult>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(50)]
        public string Content { get; set; }

        //public string? ImagePath { get; set; }

        //[FileExtensions]
        //public IFormFile? ImageFormFile { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }
    }
}
