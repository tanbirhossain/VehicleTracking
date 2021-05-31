using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Utils.Routes;

namespace VehicleTracking.Api.Controllers.V1
{
    public class AccountController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.Registration)]
        public async Task<IActionResult> Registration(RegistrationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet(ApiRoutes.Account.All)]
        public async Task<IActionResult> GetAllClient()
        {
            return Ok(await _mediator.Send(new GetAllClientQuery()));
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.Login)]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
      

    }
}
