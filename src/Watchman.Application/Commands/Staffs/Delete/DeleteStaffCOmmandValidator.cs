using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Application.Commands.Images.Delete;

namespace Watchman.Application.Commands.Staffs.Delete {

  public class DeleteStaffCommandValidator : AbstractValidator<DeleteImageCommand> {

    public DeleteStaffCommandValidator() {
      RuleFor(x => x.Id)
        .NotNull()
        .WithMessage("StaffId cannot be null");
    }
  }
}