using AutoFixture;
using CleanArquitectureNet.Domain;
using CleanArquitectureNet.Infrastructure.Persistence;
using CleanArquitectureNet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArquitectureNet.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static void AddDataVideoRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var videos = fixture.CreateMany<Video>().ToList();

            videos.Add(fixture.Build<Video>()
                        .With(tr => tr.CreatedBy, "system")
                        .Create());

            streamerDbContextFake.Videos!.AddRange(videos);
            streamerDbContextFake.SaveChanges();
                        
        }
    }
}
