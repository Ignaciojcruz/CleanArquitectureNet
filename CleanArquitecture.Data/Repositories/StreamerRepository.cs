using CleanArquitectureNet.Application.Contracts.Persistence;
using CleanArquitectureNet.Domain;
using CleanArquitectureNet.Infrastructure.Persistence;

namespace CleanArquitectureNet.Infrastructure.Repositories
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        public StreamerRepository(StreamerDbContext context) : base(context) 
        { }
    }
}
