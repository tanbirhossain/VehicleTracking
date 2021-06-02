using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Application.Core.Responses.Query;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Core.Handlers.Query
{
    public class GetVehiclesByClientIdHandler : IRequestHandler<GetVehiclesByClientIdQuery, List<GetVehiclesByClientIdResponse>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IContextRepository _httpContextRepository;

        public GetVehiclesByClientIdHandler(IVehicleRepository vehicleRepository, IContextRepository httpContextRepository)
        {
            _vehicleRepository = vehicleRepository;
            _httpContextRepository = httpContextRepository;
        }
        public async Task<List<GetVehiclesByClientIdResponse>> Handle(GetVehiclesByClientIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _vehicleRepository.GetVehiclesByClientId(_httpContextRepository.GetUserId());
            return result.Adapt<List<GetVehiclesByClientIdResponse>>();
        }
    }
}
