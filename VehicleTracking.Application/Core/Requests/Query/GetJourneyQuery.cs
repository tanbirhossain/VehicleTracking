using MediatR;
using System;
using System.Collections.Generic;
using VehicleTracking.Application.Core.Responses.Query;

namespace VehicleTracking.Application.Core.Requests.Query
{
    public class GetJourneyQuery : IRequest<List<GetJourneyResponse>>
    {
        public long VehicleId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End{ get; set; }

    } 
}
