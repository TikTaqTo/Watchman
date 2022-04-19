using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMoviesQuery : IRequest<MoviesReply> {

    public RetrieveMoviesQuery(int top) {
      Top = top;
    }

    public int Top { get; }
  }
}