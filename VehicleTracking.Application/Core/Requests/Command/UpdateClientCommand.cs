using MediatR;
using VehicleTracking.Application.Core.Responses.Command;

namespace VehicleTracking.Application.Core.Requests.Command
{
    public class UpdateClientCommand : IRequest<UpdateClientResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
