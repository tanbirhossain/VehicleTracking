using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Application.Services;
using VehicleTracking.Utils.Routes;

namespace VehicleTracking.Api.Controllers.V1
{
    public class PositionController : BaseV1Controller
    {
        private readonly IMediator _mediator;
        private readonly IGoogleApiService _googleApiService;

        public PositionController(IMediator mediator, IGoogleApiService googleApiService)
        {
            _mediator = mediator;
            _googleApiService = googleApiService;
        }

        [Authorize]
        [HttpPost(ApiRoutes.Position.Add)]
        public async Task<IActionResult> AddPosition(AddPositionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet(ApiRoutes.Position.CurrentPosition)]
        public async Task<IActionResult> GetCurrentPosition(long vehicleId)
        {
            return Ok(await _mediator.Send(new GetCurrentPositionQuery { VehicleId = vehicleId }));
        }

        [Authorize]
        [HttpGet(ApiRoutes.Position.Journey)]
        public async Task<IActionResult> GetJourney(long vehicleId, DateTime start, DateTime end)
        {
            return Ok(await _mediator.Send(new GetJourneyQuery { VehicleId = vehicleId, Start = start.ToUniversalTime(), End = end.ToUniversalTime() }));
        }
        
        [AllowAnonymous]
        [HttpGet(ApiRoutes.Position.map)]
        public async Task<IActionResult> GetMap(double latitude, double longitude)
        {
            var result = await _googleApiService.GetGeoData(latitude, longitude);
            return Ok(result);
        }
    }
}
