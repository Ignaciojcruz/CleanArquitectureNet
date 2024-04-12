using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Persistence;
using CleanArquitectureNet.Application.Features.Videos.Queries.GetVideosList;
using CleanArquitectureNet.Application.Mappings;
using CleanArquitectureNet.Application.UnitTests.Mocks;
using CleanArquitectureNet.Infrastructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArquitectureNet.Application.UnitTests.Features.Video.Queries
{
    public class GetVideosListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetVideosListQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockVideoRepository.AddDataVideoRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task GetVideoListTest()
        {
            var handler = new GetVideosListQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetVideosListQuery("system");

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<VideosVm>>();

            result.Count.ShouldBe(1);
            
        }
    }
}
