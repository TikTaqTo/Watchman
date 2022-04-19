using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Movies.Create {

  public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieReply> {
    private readonly IMovieService _moviesService;

    public CreateMovieCommandHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MovieReply> Handle(CreateMovieCommand request, CancellationToken cancellationToken) {
      return await _moviesService.CreateMovie(request.Movie);
    }
  }
}