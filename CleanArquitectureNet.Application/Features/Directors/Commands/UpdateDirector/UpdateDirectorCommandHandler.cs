using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Persistence;
using CleanArquitectureNet.Application.Exceptions;
using CleanArquitectureNet.Domain;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CleanArquitectureNet.Application.Features.Directors.Commands.UpdateDirector
{
    public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDirectorCommandHandler> _logger;

        public UpdateDirectorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateDirectorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
        {
            var directorToUpdate = await _unitOfWork.DirectorRepository.GetByIdAsync(request.Id);

            if (directorToUpdate == null)
            {
                _logger.LogError($"No se encontró el director id {request.Id}");
                throw new NotFoundException(nameof(Director), request.Id);
            }

            _mapper.Map(request, directorToUpdate, typeof(UpdateDirectorCommand), typeof(Director));

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operación fue exitosa actualizando el director {request.Id}");

            return Unit.Value;

        }
    }
}
