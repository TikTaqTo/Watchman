using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchman.Application.Commands.StaffPositions.Delete
{
    public class DeleteStaffPositionCommandValidator : AbstractValidator<DeleteStaffPositionCommand>
    {
        public DeleteStaffPositionCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithMessage("Id can not be smaller than 0");
        }
    }
}