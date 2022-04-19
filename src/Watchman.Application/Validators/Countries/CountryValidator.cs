using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Application.Validators.Countries {

  public class CountryValidator : AbstractValidator<Country> {

    public CountryValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Country name can not be null")
        .NotEmpty()
        .WithMessage("Country name can not be empty")
        .MaximumLength(50)
        .WithMessage("Country name can not be more than 50 chars");
    }
  }
}