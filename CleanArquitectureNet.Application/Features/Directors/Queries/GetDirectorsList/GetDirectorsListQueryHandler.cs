using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Persistence;
using MediatR;

namespace CleanArquitectureNet.Application.Features.Directors.Queries.GetDirectorsList
{
    public class GetDirectorsListQueryHandler : IRequestHandler<GetDirectorsListQuery, List<DirectorsVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDirectorsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DirectorsVm>> Handle(GetDirectorsListQuery request, CancellationToken cancellationToken)
        {
            var directorList = await _unitOfWork.DirectorRepository.GetAllAsync();

            return _mapper.Map<List<DirectorsVm>>(directorList);
        }
    }
}
