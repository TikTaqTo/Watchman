using FluentValidation;
using Watchman.Application.Validators.Genres;

namespace Watchman.Application.Commands.Genres.Create {

  public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand> {

    public CreateGenreCommandValidator() {
      RuleFor(x => x.Genre)
                .SetValidator(new GenreValidator())
                .WithMessage("Invalid genre entity");
    }
  }
}