﻿using System;

namespace VehicleTracking.Infrastructure.Domain.Entities
{
    public class Position
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
