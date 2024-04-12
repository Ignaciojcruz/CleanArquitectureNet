using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Logging;
using CleanArquitectureNet.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArquitectureNet.Infrastructure.Repositories;
using Moq;
using CleanArquitectureNet.Application.UnitTests.Mocks;
using CleanArquitectureNet.Application.Mappings;
using Xunit;
using Shouldly;

namespace CleanArquitectureNet.Application.UnitTests.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<CreateStreamerCommandHandler>> _logger;

        public CreateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _emailService = new Mock<IEmailService>();

            _logger = new Mock<ILogger<CreateStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task CreateStreamerCommand_InputStreamer_ReturnsNumber()
        {
            var streamerInput = new CreateStreamerCommand
            {
                Nombre = "Vaxy Streaming",
                Url = "https://vaxystreaming.com"
            };

            var handler = new CreateStreamerCommandHandler(_unitOfWork.Object
                                                            , _mapper
                                                            , _emailService.Object
                                                            , _logger.Object);

            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<int>();

        }
    }
}
