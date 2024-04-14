using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Persistence;
using CleanArquitectureNet.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using CleanArquitectureNet.Domain;

namespace CleanArquitectureNet.Application.Features.Directors.Commands.DeleteDirector
{
    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteDirectorCommandHandler> _logger;

        public DeleteDirectorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteDirectorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            var directorToDelete = await _unitOfWork.DirectorRepository.GetByIdAsync(request.Id);

            if(directorToDelete == null)
            {
                _logger.LogError($"{request.Id} directr no existe en el sistema");
                throw new NotFoundException(nameof(Director), request.Id);
            }

            _unitOfWork.DirectorRepository.DeleteEntity(directorToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.Id} director fue eliminado con éxito");

            return Unit.Value;
        }
    }
}
