﻿using MediatR;
using System.Collections.Generic;
using VehicleTracking.Application.Core.Responses.Query;

namespace VehicleTracking.Application.Core.Requests.Query
{
    public class GetAllClientQuery : IRequest<List<GetAllClientResponse>>
    {
    } 
}
