using CleanArquitectureNet.Domain.Common;

namespace CleanArquitectureNet.Domain
{
    public class VideoActor : BaseDomainModel
    {
        public int VideoId { get; set; }
        public int ActorId { get; set; }
    }
}
