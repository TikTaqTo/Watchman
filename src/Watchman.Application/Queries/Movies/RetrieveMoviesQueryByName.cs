using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMoviesQueryByName : IRequest<MoviesReply> {

    public RetrieveMoviesQueryByName(string name) {
      Name = name;
    }

    public string Name { get; }
  }
}