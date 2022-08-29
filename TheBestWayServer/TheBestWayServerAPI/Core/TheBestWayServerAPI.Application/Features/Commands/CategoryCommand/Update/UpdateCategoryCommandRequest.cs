using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.CategoryCommand.Update
{
    public class UpdateCategoryCommandRequest:IRequest<CommandNoMessageResult>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        [MinLength(3)]
        public string Description { get; set; }

        //secret..
        public int BaseCategoryId { get; set; }
    }
}
