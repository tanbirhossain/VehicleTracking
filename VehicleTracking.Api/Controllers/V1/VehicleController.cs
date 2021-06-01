using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Utils.Routes;

namespace VehicleTracking.Api.Controllers.V1
{

    public class VehicleController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost(ApiRoutes.Vehicle.Add)]
        public async Task<IActionResult> Add(AddVehicleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet(ApiRoutes.Vehicle.GetVehicles)]
        public async Task<IActionResult> GetVehicles()
        {
            return Ok(await _mediator.Send(new GetVehiclesByClientIdQuery()));
        }
    }
}
