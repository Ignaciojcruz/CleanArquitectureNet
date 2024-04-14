using CleanArquitectureNet.Application.Contracts.Persistence;
using CleanArquitectureNet.Domain;
using CleanArquitectureNet.Infrastructure.Persistence;

namespace CleanArquitectureNet.Infrastructure.Repositories
{
    public class DirectorRepository : RepositoryBase<Director>, IDirectorRepository
    {
        public DirectorRepository(StreamerDbContext context) : base(context)
        { }
    }
}
