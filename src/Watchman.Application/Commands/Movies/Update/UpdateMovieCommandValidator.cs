using FluentValidation;
using Watchman.Application.Validators.Movies;

namespace Watchman.Application.Commands.Movies.Update {

  public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand> {

    public UpdateMovieCommandValidator() {
      RuleFor(x => x.Movie)
                .SetValidator(new MoviesValidator())
                .WithMessage("Invalid movie entity");
    }
  }
}