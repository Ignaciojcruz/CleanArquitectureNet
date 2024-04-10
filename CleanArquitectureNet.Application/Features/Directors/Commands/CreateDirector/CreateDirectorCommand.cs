using MediatR;

namespace CleanArquitectureNet.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int VideoId { get; set; }
    }
}
