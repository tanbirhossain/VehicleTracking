using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Validators;
using VehicleTracking.Infrastructure.Repositories;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Ioc
{
    public static class DependencyInjection
    {
        public static void BuildServices(this IServiceCollection services)
        {
            ////// Repository
            services.AddTransient<IClientRepository, ClientRepository>();




            // mediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // validator
            services.BuildValidator();
        }
    }
}
