﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking.Utils.Routes
{
    public static class ApiRoutes
    {
        //private const string 
        public static class Account
        {
            public const string Login = "api/v1/Account/Login";
            public const string Registration = "api/v1/Account/Registration";
            public const string All = "api/v1/Account/All";
          
        }  
        public static class Vehicle
        {
            public const string Add = "api/v1/Vehicle/Add";
            public const string GetByClientId = "api/v1/Account/GetByClinetId/{clientId}";
          
        }
    }
}
