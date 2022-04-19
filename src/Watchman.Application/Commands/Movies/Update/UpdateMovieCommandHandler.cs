using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Movies.Update {

  public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieReply> {
    private readonly IMovieService _moviesService;

    public UpdateMovieCommandHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MovieReply> Handle(UpdateMovieCommand request, CancellationToken cancellationToken) {
      return await _moviesService.UpdateMovieById(request.Movie);
    }
  }
}