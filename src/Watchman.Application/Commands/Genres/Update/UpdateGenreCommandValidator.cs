using FluentValidation;
using Watchman.Application.Validators.Genres;

namespace Watchman.Application.Commands.Genres.Update {

  public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> {

    public UpdateGenreCommandValidator() {
      RuleFor(x => x.Genre)
                .SetValidator(new GenreValidator())
                .WithMessage("Invalid genre entity");
    }
  }
}