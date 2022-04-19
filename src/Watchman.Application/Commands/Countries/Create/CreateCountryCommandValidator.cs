using FluentValidation;
using Watchman.Application.Validators.Countries;

namespace Watchman.Application.Commands.Countries.Create {

  public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand> {

    public CreateCountryCommandValidator() {
      RuleFor(x => x.Country)
                .SetValidator(new CountryValidator())
                .WithMessage("Invalid country entity");
    }
  }
}