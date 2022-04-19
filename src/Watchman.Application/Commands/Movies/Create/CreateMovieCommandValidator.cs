using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Application.Validators.Movies;

namespace Watchman.Application.Commands.Movies.Create {

  public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand> {

    public CreateMovieCommandValidator() {
      RuleFor(x => x.Movie)
                .SetValidator(new MoviesValidator())
                .WithMessage("Invalid movie entity");
    }
  }
}