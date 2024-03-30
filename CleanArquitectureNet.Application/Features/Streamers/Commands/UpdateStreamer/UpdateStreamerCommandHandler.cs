using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Persistence;
using CleanArquitectureNet.Application.Exceptions;
using CleanArquitectureNet.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitectureNet.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStreamerCommandHandler> _logger;

        public UpdateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<UpdateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdate = await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate == null) 
            {
                _logger.LogError($"No se encontró el streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));

            await _streamerRepository.UpdateAsync(streamerToUpdate);
            
            _logger.LogInformation($"La operación fue exitosa actualizando el streamer {request.Id}");

            return Unit.Value;
        }
    }
}
