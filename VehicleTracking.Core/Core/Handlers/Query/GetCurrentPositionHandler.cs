using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Application.Core.Responses.Query;
using VehicleTracking.Application.Services;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Core.Handlers.Query
{
    public class GetCurrentPositionHandler : IRequestHandler<GetCurrentPositionQuery, GetCurrentPositionResponse>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IGoogleApiService _googleApiService;

        public GetCurrentPositionHandler(IPositionRepository positionRepository, IGoogleApiService googleApiService)
        {
            _positionRepository = positionRepository;
            _googleApiService = googleApiService;
        }
        public async Task<GetCurrentPositionResponse> Handle(GetCurrentPositionQuery request, CancellationToken cancellationToken)
        {
            var result = await _positionRepository.CurrentPositionByVehicleId(request.VehicleId);
            var response = result.Adapt<GetCurrentPositionResponse>();
            response.Address = await _googleApiService.GetGeoAddress(response.Latitude, response.Longitude);
            
            return response;
        }


    }
}
