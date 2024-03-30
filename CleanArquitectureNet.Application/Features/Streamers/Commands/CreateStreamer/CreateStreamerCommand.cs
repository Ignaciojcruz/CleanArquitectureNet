using MediatR;

namespace CleanArquitectureNet.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
