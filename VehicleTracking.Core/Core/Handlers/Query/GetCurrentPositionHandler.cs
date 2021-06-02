using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Application.Core.Responses.Query;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Core.Handlers.Query
{
    public class GetCurrentPositionHandler : IRequestHandler<GetCurrentPositionQuery, GetCurrentPositionResponse>
    {
        private readonly IPositionRepository _positionRepository;

        public GetCurrentPositionHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public async Task<GetCurrentPositionResponse> Handle(GetCurrentPositionQuery request, CancellationToken cancellationToken)
        {
            var result = await _positionRepository.CurrentPositionByVehicleId(request.VehicleId);
            return result.Adapt<GetCurrentPositionResponse>();
        }

        
    }
}
