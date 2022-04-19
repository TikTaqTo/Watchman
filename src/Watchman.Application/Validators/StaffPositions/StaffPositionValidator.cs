using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Application.Validators.StaffPositions {

  public class StaffPositionValidator : AbstractValidator<StaffPosition> {

    public StaffPositionValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("StaffPosition name can not be null")
        .NotEmpty()
        .WithMessage("StaffPosition name can not be empty")
        .MaximumLength(20)
        .WithMessage("StaffPosition name can not be more than 20 chars");
    }
  }
}