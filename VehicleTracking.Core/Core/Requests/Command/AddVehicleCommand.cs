using MediatR;
using VehicleTracking.Application.Core.Responses.Command;

namespace VehicleTracking.Application.Core.Requests.Command
{
    public class AddVehicleCommand : IRequest<AddVehicleResponse>
    {
        public string Name { get; set; }
    }
}
