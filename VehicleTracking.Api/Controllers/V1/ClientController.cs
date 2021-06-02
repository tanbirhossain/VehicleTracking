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
    public class ClientController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet(ApiRoutes.Client.GetUserInfo)]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(await _mediator.Send(new GetUserInfoQuery()));
        }
        
        [Authorize]
        [HttpPut(ApiRoutes.Client.Update)]
        public async Task<IActionResult> Update(UpdateClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}