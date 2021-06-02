using MediatR;
using VehicleTracking.Application.Core.Responses.Command;

namespace VehicleTracking.Application.Core.Requests.Command
{
    public class AddPositionCommand : IRequest<AddPositionResponse>
    {
        public string DeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
