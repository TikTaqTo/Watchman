using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Application.Validators.Staffs;

namespace Watchman.Application.Commands.Staffs.Create {

  public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand> {

    public CreateStaffCommandValidator() {
      RuleFor(x => x.Staff)
                .SetValidator(new StaffValidator())
                .WithMessage("Invalid staff entity");
    }
  }
}