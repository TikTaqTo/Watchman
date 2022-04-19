using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMovieQueryByIdValidator : AbstractValidator<RetrieveMovieQueryById> {

    public RetrieveMovieQueryByIdValidator() {
      RuleFor(x => x.MovieId)
        .NotNull()
        .WithMessage("Movie id can not be null");
    }
  }
}