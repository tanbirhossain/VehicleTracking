﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleTracking.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        //private IMediator _mediator;
        //protected IMediator mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
