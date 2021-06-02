using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Responses.Command;
using VehicleTracking.Infrastructure.Domain.Entities;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Core.Handlers.Command
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, UpdateClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContextRepository _contextRepository;

        public UpdateClientHandler(IClientRepository clientRepository, IContextRepository contextRepository)
        {
            _clientRepository = clientRepository;
            _contextRepository = contextRepository;
        }
        public async Task<UpdateClientResponse> Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = command.Adapt<Client>();
            client.Id = _contextRepository.GetUserId();
            var result = await _clientRepository.UpdateClient(client);
            return result.Adapt<UpdateClientResponse>();
        }
    }  
  
}
