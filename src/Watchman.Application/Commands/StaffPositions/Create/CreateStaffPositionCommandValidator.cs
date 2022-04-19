using FluentValidation;
using Watchman.Application.Validators.Countries;
using Watchman.Application.Validators.StaffPositions;

namespace Watchman.Application.Commands.StaffPositions.Create {

  public class CreateStaffPositionCommandValidator : AbstractValidator<CreateStaffPositionCommand> {

    public CreateStaffPositionCommandValidator() {
      RuleFor(x => x.StaffPosition)
                .SetValidator(new StaffPositionValidator())
                .WithMessage("Invalid country entity");
    }
  }
}