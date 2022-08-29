using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.BaseCategoryCommand.Create
{
    public class CreateBaseCategoryCommandHandler : IRequestHandler<CreateBaseCategoryCommandRequest, Result>
    {
        private readonly IBaseCategoryWriteRepository _baseCategoryWriteRepository;
        private IMapper _mapper;
        private readonly ILogger<CreateBaseCategoryCommandHandler> _logger;

        public CreateBaseCategoryCommandHandler(IBaseCategoryWriteRepository baseCategoryWriteRepository, IMapper mapper, ILogger<CreateBaseCategoryCommandHandler> logger)
        {
            _baseCategoryWriteRepository = baseCategoryWriteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateBaseCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var baseCategory = _mapper.Map<BaseCategory>(request);
            int id = await _baseCategoryWriteRepository.AddAsync(baseCategory);
            _logger.LogInformation("Base category başarıyla eklendi.");
            return new CommandWithMessageResult(201, $"Added base category  {id} ID successfully.");
        }
    }
}
