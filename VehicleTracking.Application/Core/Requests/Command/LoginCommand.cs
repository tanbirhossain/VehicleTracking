using MediatR;
using VehicleTracking.Application.Core.Responses.Command;


namespace VehicleTracking.Application.Core.Requests.Command
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
