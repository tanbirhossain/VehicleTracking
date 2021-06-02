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
    public class GetUserInfoHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContextRepository _contextRepository;

        public GetUserInfoHandler(IClientRepository clientRepository,IContextRepository contextRepository)
        {
            _clientRepository = clientRepository;
            _contextRepository = contextRepository;
        }
        public async Task<GetUserInfoResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _clientRepository.GetClientById(_contextRepository.GetUserId());
            return result.Adapt<GetUserInfoResponse>();
        }
    }
}
