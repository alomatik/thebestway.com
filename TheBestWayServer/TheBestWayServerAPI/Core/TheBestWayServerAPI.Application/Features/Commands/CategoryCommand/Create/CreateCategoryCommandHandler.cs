using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.CategoryCommand.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CommandWithMessageResult>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }

        public async Task<CommandWithMessageResult> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);
            category.CreatedDate = DateTime.Now;
            int id = await _categoryWriteRepository.AddAsync(category);
            return new CommandWithMessageResult(StatusCodes.Status201Created, $"Added category {id} ID successfully.");
        }
    }
}
