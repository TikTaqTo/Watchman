using FluentValidation;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Application.Validators.Genres {

  public class GenreValidator : AbstractValidator<Genre> {

    public GenreValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Genre name can not be null")
        .NotEmpty()
        .WithMessage("Genre name can not be empty")
        .MaximumLength(30)
        .WithMessage("Genre name can not be more than 30 chars");
    }
  }
}