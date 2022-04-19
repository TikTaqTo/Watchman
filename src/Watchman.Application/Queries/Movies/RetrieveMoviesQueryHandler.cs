using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMoviesQueryHandler : IRequestHandler<RetrieveMoviesQuery, MoviesReply> {
    private readonly IMovieService _moviesService;

    public RetrieveMoviesQueryHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MoviesReply> Handle(RetrieveMoviesQuery request, CancellationToken cancellationToken) {
      var moviesReply = await _moviesService.RetrieveMovies(request.Top);
      return moviesReply;
    }
  }
}