using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Infrastructure;
using CleanArquitectureNet.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArquitectureNet.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArquitectureNet.Application.Mappings;
using CleanArquitectureNet.Application.UnitTests.Mocks;
using CleanArquitectureNet.Infrastructure.Email;
using CleanArquitectureNet.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArquitectureNet.Application.UnitTests.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;        
        private readonly Mock<ILogger<DeleteStreamerCommandHandler>> _logger;

        public DeleteStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
                        
            _logger = new Mock<ILogger<DeleteStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task DeleteStreamerCommand_InputStreamerById_ReturnsUnit()
        {
            var stremerInput = new DeleteStreamerCommand
            {
                Id = 1
            };

            var handler = new DeleteStreamerCommandHandler(_unitOfWork.Object
                                                            , _mapper
                                                            , _logger.Object);        

            var result = await handler.Handle(stremerInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
            
        }
    }
}
