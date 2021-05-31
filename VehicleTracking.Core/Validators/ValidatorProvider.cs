using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;

namespace VehicleTracking.Application.Validators
{
    public static class ValidatorProvider
    {
        public static void BuildValidator(this IServiceCollection services)
        {
            //validator
            services.AddTransient<IValidator<RegistrationCommand>, RegistrationCommandValidator>();
            services.AddTransient<IValidator<LoginCommand>, LoginCommandValidator>();
        }
    }
}
