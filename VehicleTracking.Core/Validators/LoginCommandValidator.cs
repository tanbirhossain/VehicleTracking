using FluentValidation;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Infrastructure.Repositories.Interfaces;
using VehicleTracking.Utils;

namespace VehicleTracking.Application.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IClientRepository _clientRepository;

        public LoginCommandValidator(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            bool firstPhasePassed = true;

            RuleFor(e => e.Email).NotEmpty()
                 .OnAnyFailure(x => { firstPhasePassed = false; });
            RuleFor(e => e.Password).NotEmpty()
              .OnAnyFailure(x => { firstPhasePassed = false; });

            When(x => firstPhasePassed, () =>
            {

                RuleFor(x => x)
                .NotEmpty()
               .MustAsync((x, cancellation) => IsAuthorized(x)).WithMessage("Wrong email or password");
            });

        }

        protected async Task<bool> IsAuthorized(LoginCommand command)
        {
            try
            {
                var client = await _clientRepository.GetClientByEmail(command.Email);
                if (client == null)
                {
                    return false;

                }
                else if (!Authenticator.ValidatePassword(command.Password, client.Password))
                {
                    return false;

                }
                return true;
            }
            catch (System.Exception ex)
            {

                return false;

            }
           
        }
    }
}
