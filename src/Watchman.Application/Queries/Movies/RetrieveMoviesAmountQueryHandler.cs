using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMoviesAmountQueryHandler : IRequestHandler<RetrieveMoviesAmountQuery, MovieAmountReply> {
    private readonly IMovieService _moviesService;

    public RetrieveMoviesAmountQueryHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MovieAmountReply> Handle(RetrieveMoviesAmountQuery request, CancellationToken cancellationToken) {
      var moviesReply = await _moviesService.RetrieveMoviesAmount();
      return moviesReply;
    }
  }
}