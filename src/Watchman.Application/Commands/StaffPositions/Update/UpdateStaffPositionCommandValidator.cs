using FluentValidation;
using Watchman.Application.Validators.Genres;
using Watchman.Application.Validators.StaffPositions;

namespace Watchman.Application.Commands.StaffPositions.Update
{
    public class UpdateStaffPositionCommandValidator : AbstractValidator<UpdateStaffPositionCommand>
    {
        public UpdateStaffPositionCommandValidator()
        {
            RuleFor(x => x.StaffPosition)
                      .SetValidator(new StaffPositionValidator())
                      .WithMessage("Invalid genre entity");
        }
    }
}