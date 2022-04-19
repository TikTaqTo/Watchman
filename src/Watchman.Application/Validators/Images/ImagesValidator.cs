using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Media;

namespace Watchman.Application.Validators.Images {

  public class ImagesValidator : AbstractValidator<Image> {

    public ImagesValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Image name can not be null")
        .NotEmpty()
        .WithMessage("Image name can not be empty")
        .MaximumLength(30)
        .WithMessage("Image name can not be more than 30 chars");
    }
  }
}