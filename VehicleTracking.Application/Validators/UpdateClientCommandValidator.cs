using FluentValidation;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Application.Validators
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty()
                .Length(0, 100);
            RuleFor(e => e.LastName)
                .NotEmpty()
                .Length(0, 100);
        }
    }

}
