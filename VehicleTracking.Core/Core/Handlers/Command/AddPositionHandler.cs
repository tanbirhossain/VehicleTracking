using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Responses.Command;
using VehicleTracking.Infrastructure.Domain.Entities;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Core.Handlers.Command
{
    public class AddPositionHandler : IRequestHandler<AddPositionCommand, AddPositionResponse>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public AddPositionHandler(IPositionRepository positionRepository, IVehicleRepository vehicleRepository)
        {
            _positionRepository = positionRepository;
            _vehicleRepository = vehicleRepository;
        }
        public async Task<AddPositionResponse> Handle(AddPositionCommand command, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleByDeviceId(command.DeviceId);

            var position = command.Adapt<Position>();
            position.AddedDate = DateTime.UtcNow;
            position.VehicleId = vehicle.Id;


            var result = await _positionRepository.InsertPosition(position);
            return result.Adapt<AddPositionResponse>();
        }
    }

}
