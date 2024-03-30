using CleanArquitectureNet.Domain;

namespace CleanArquitectureNet.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);

        Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
