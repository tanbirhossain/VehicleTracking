using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracking.Infrastructure.Domain.Common
{
    public class AuditableEntity
    {
        public long? AddedBy { get; set; }

        public DateTime? AddedDate { get; set; }

        public long? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
