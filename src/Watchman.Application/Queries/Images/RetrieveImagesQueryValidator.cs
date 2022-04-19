using FluentValidation;

namespace Watchman.Application.Queries.Images {

  public class RetrieveImagesQueryValidator : AbstractValidator<RetrieveImagesQuery> {

    public RetrieveImagesQueryValidator() {
      RuleFor(x => x.Top)
          .GreaterThan(0)
          .WithMessage("Images count should be more than 0");
    }
  }
}