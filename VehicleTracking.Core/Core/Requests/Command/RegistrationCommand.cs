using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Responses.Command;

namespace VehicleTracking.Application.Core.Requests.Command
{
    public class RegistrationCommand : IRequest<RegistrationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
