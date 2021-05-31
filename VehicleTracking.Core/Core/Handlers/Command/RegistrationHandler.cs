using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Responses.Command;
using VehicleTracking.Infrastructure.Domain.Entities;
using VehicleTracking.Infrastructure.Repositories.Interfaces;
using VehicleTracking.Utils;

namespace VehicleTracking.Application.Core.Handlers.Command
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, RegistrationResponse>
    {
        private readonly IClientRepository _clientRepository;

        public RegistrationHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<RegistrationResponse> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var client = request.Adapt<Client>();
            client.Password = Authenticator.GetHashPassword(request.Password);
            var result = await _clientRepository.InsertClient(client);
            return result.Adapt<RegistrationResponse>();
        }
    }  
  
}
