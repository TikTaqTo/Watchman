using FluentValidation;
using Watchman.Application.Validators.Countries;

namespace Watchman.Application.Commands.Countries.Update {

  public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand> {

    public UpdateCountryCommandValidator() {
      RuleFor(x => x.Country)
                .SetValidator(new CountryValidator())
                .WithMessage("Invalid country entity");
    }
  }
}