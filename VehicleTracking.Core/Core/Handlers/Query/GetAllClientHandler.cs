using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Application.Core.Responses.Query;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Core.Handlers.Query
{
    public class GetAllClientHandler : IRequestHandler<GetAllClientQuery, List<GetAllClientResponse>>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<GetAllClientResponse>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            var result = await _clientRepository.GetAllClients();
            return result.Adapt<List<GetAllClientResponse>>();
        }
    }
}
