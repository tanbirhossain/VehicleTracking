using MediatR;
using VehicleTracking.Application.Core.Responses.Query;

namespace VehicleTracking.Application.Core.Requests.Query
{
    public class GetCurrentPositionQuery : IRequest<GetCurrentPositionResponse>
    {
        public long VehicleId { get; set; }

    } 
}
