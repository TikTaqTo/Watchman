using FluentValidation;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMovieQueryPaginationValidator : AbstractValidator<Movie> {
  }
}