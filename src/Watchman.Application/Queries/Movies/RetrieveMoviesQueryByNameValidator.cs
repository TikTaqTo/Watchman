using FluentValidation;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMoviesQueryByNameValidator : AbstractValidator<RetrieveMoviesQueryByName> {

    public RetrieveMoviesQueryByNameValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Movie name can not be null")
        .NotEmpty()
        .WithMessage("Movie name can not be empty")
        .MaximumLength(190)
        .WithMessage("Movie name can not be more than 190 chars");
    }
  }
}