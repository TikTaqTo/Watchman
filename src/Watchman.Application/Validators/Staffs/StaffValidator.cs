using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Application.Validators.Staffs {

  public class StaffValidator : AbstractValidator<Staff> {

    public StaffValidator() {
      RuleFor(x => x.Name)
       .NotNull()
       .WithMessage("Staff name can not be null")
       .NotEmpty()
       .WithMessage("Staff name can not be empty")
       .MaximumLength(90)
       .WithMessage("Staff name can not be more than 90 chars");

      RuleFor(x => x.Surname)
       .NotNull()
       .WithMessage("Staff surname can not be null")
       .NotEmpty()
       .WithMessage("Staff surname can not be empty")
       .MaximumLength(110)
       .WithMessage("Staff surname can not be more than 110 chars");
    }
  }
}