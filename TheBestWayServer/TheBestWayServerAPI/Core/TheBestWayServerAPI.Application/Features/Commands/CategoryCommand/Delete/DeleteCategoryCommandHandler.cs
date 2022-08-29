using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.CategoryCommand.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, CommandNoMessageResult>
    {

        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }


        public async Task<CommandNoMessageResult> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryReadRepository.GetByIdAsync(request.Id);
            if (category != null)
            {
                _categoryWriteRepository.Delete(category);
                return new CommandNoMessageResult(204);
            }
            throw new NotFoundException($"Not found {request.Id} ID category.");

        }
    }
}
