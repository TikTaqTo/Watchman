using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMoviesQueryByNameHandler : IRequestHandler<RetrieveMoviesQueryByName, MoviesReply> {
    private readonly IMovieService _moviesService;

    public RetrieveMoviesQueryByNameHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MoviesReply> Handle(RetrieveMoviesQueryByName request, CancellationToken cancellationToken) {
      var moviesReply = await _moviesService.RetrieveMoviesByName(request.Name);
      return moviesReply;
    }
  }
}