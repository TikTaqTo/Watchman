using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchman.Application.Queries.Countries {

  public class RetrieveCountriesQueryValidator : AbstractValidator<RetrieveCountriesQuery> {

    public RetrieveCountriesQueryValidator() {
      RuleFor(x => x.Top)
          .GreaterThan(0)
          .WithMessage("Country count should be more than 0");
    }
  }
}