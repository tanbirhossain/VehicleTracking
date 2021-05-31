using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Infrastructure.Repositories.Interfaces;
using VehicleTracking.Utils;

namespace VehicleTracking.Application.Validators
{
    public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
    {
        private readonly IClientRepository _clientRepository;

        public RegistrationCommandValidator(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            bool firstPhasePassed = true;

            RuleFor(e => e.FirstName).NotEmpty();
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.Email).NotEmpty();

            RuleFor(e => e.Password).NotEmpty()
             .OnAnyFailure(x => { firstPhasePassed = false; });


            When(x => firstPhasePassed, () =>
            {

                RuleFor(x => x)
                .NotEmpty()
               .MustAsync((x, cancellation) => IsEmailExists(x)).WithMessage("Email Must be unique");
            });


        }

        protected async Task<bool> IsEmailExists(RegistrationCommand command)
        {
            var exists = await _clientRepository.GetClientByEmail(command.Email);
            if (exists != null)
            {
                return false;

            }
            return true;
        }
    }
}
