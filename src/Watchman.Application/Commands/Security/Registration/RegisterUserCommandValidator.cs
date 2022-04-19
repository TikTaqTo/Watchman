using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Application.Validators.Security;

namespace Watchman.Application.Commands.Security.Registration {

  public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand> {

    public RegisterUserCommandValidator() {
      RuleFor(x => x.Request)
                .SetValidator(new RegisterRequestValidator())
                .WithMessage("Invalid request entity");
    }
  }
}