using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.CategoryCommand.Delete
{
    public class DeleteCategoryCommandRequest:IRequest<CommandNoMessageResult>
    {
        [Required]
        public int Id { get; set; }
    }
}
