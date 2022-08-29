using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.PostCommand.Update
{
    public class UpdatePostCommandRequest:IRequest<CommandNoMessageResult>
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        //public string? ImagePath { get; set; }

        //[FileExtensions]
        //public IFormFile? ImageFormFile { get; set; }

        public int CategoryId { get; set; }
    }
}
