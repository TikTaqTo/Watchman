using MediatR;
using Watchman.Domain.EntityModels.Film;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Movies.Update {

  public class UpdateMovieCommand : IRequest<MovieReply> {

    public UpdateMovieCommand(Movie movie) {
      Movie = movie;
    }

    public Movie Movie { get; }
  }
}