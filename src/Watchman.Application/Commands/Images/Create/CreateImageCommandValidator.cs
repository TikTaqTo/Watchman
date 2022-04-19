using FluentValidation;
using Watchman.Application.Validators.Images;

namespace Watchman.Application.Commands.Images.Create {

  internal class CreateImageCommandValidator : AbstractValidator<CreateImageCommand> {

    public CreateImageCommandValidator() {
      RuleFor(x => x.Image)
                .SetValidator(new ImagesValidator())
                .WithMessage("Invalid image entity");
    }
  }
}