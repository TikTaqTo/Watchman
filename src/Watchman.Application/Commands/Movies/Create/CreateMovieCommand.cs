using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Film;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Movies.Create {

  public class CreateMovieCommand : IRequest<MovieReply> {

    public CreateMovieCommand(Movie movie) {
      Movie = movie;
    }

    public Movie Movie { get; set; }
  }
}