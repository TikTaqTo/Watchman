using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Movies.AddGenre {

  public class AddGenreToMovieCommandHandler : IRequestHandler<AddGenreToMovieCommand, MovieReply> {
    private readonly IMovieService _moviesService;

    public AddGenreToMovieCommandHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MovieReply> Handle(AddGenreToMovieCommand request, CancellationToken cancellationToken) {
      return await _moviesService.AddGenreToMovie(request.Request);
    }
  }
}