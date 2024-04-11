using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Infrastructure;
using CleanArquitectureNet.Application.Contracts.Persistence;
using CleanArquitectureNet.Application.Models;
using CleanArquitectureNet.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitectureNet.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler( IUnitOfWork unitOfWork
                                            //IStreamerRepository streamerRepository
                                            , IMapper mapper
                                            , IEmailService emailService
                                            , ILogger<CreateStreamerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            //var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

            _unitOfWork.StreamerRepository.AddEntity(streamerEntity);

            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                throw new Exception($"No se pudo insertar el record del streamer");
            }

            _logger.LogInformation($"Streamer {streamerEntity.Id} fue creado exitosamente");

            await SendEmail(streamerEntity);

            return streamerEntity.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "vaxi.drez.social@gmail.com",
                Body = "La compañía de streamer se creó correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailService.SendEmailAsync(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al enviar el email de {streamer.Id}");
            }

        }
    }
}
