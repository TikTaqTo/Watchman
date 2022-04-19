using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchman.Application.Queries.Staffs {

  public class RetrieveStaffByIdQueryValidator : AbstractValidator<RetrieveStaffByIdQuery> {

    public RetrieveStaffByIdQueryValidator() {
      RuleFor(x => x.StaffId)
        .NotNull()
        .WithMessage("StaffId cannot be null");
    }
  }
}