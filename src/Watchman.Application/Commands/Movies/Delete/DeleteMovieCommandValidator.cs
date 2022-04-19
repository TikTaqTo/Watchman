using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Watchman.Application.Commands.Movies.Delete {

  public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand> {

    public DeleteMovieCommandValidator() {
      RuleFor(x => x.Id)
        .NotNull()
        .WithMessage("Movie Id cannot be null");
    }
  }
}