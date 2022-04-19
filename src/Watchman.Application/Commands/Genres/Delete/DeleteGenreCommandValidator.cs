using FluentValidation;

namespace Watchman.Application.Commands.Genres.Delete {

  public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand> {

    public DeleteGenreCommandValidator() {
      RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Id can not be smaller than 0");
    }
  }
}