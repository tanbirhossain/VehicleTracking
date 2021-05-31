using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Responses.Query;

namespace VehicleTracking.Application.Core.Requests.Query
{
    public class GetAllClientQuery : IRequest<List<GetAllClientResponse>>
    {
    }
}
