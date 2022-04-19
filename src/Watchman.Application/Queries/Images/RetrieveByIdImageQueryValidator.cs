using FluentValidation;

namespace Watchman.Application.Queries.Images {

  public class RetrieveByIdImagesQueryValidator : AbstractValidator<RetrieveByIdImageQuery> {

    public RetrieveByIdImagesQueryValidator() {
    }
  }
}