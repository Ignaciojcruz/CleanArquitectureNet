using AutoMapper;
using CleanArquitectureNet.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitectureNet.Application.Features.Streamers.Queries.GetStreamersList
{
    public class GetStreamersListQueryHandler : IRequestHandler<GetStreamersListQuery, List<StreamersVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStreamersListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<StreamersVm>> Handle(GetStreamersListQuery request, CancellationToken cancellationToken)
        {
            var streamersList = await _unitOfWork.StreamerRepository.GetAllAsync();

            return _mapper.Map<List<StreamersVm>>(streamersList);
        }
    }
}
