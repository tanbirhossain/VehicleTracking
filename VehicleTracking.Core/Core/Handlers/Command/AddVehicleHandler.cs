using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Responses.Command;
using VehicleTracking.Infrastructure.Domain.Entities;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Core.Handlers.Command
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, AddVehicleResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IHttpContextRepository _httpContextRepository;


        public AddVehicleHandler(IVehicleRepository vehicleRepository, IHttpContextRepository httpContextRepository )
        {
            _vehicleRepository = vehicleRepository;
            _httpContextRepository = httpContextRepository;
        }
        public async Task<AddVehicleResponse> Handle(AddVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehicle = command.Adapt<Vehicle>();
            vehicle.ClientId = _httpContextRepository.GetUserId();

            var result = await _vehicleRepository.InsertVehicle(vehicle);
            return result.Adapt<AddVehicleResponse>();
        }
    }

}
