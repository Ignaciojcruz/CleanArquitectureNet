using MediatR;

namespace CleanArquitectureNet.Application.Features.Directors.Commands.DeleteDirector
{
    public class DeleteDirectorCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
