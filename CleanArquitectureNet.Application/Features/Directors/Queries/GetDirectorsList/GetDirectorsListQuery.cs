using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitectureNet.Application.Features.Directors.Queries.GetDirectorsList
{
    public class GetDirectorsListQuery : IRequest<List<DirectorsVm>>
    {

    }
}
