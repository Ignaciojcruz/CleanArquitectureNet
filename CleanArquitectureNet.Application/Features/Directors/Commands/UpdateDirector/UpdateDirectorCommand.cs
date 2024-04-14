using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitectureNet.Application.Features.Directors.Commands.UpdateDirector
{
    public class UpdateDirectorCommand : IRequest
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

    }
}
