using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking.Utils.Infrastructure
{
   public class BaseResponse
    {
        public bool IsSuccess { get; set; } 
        public int Code { get; set; } = 200;
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
