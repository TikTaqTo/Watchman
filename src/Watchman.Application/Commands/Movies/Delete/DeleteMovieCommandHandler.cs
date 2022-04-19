using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Movies.Delete {

  public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, MovieReply> {
    private readonly IMovieService _moviesService;

    public DeleteMovieCommandHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public Task<MovieReply> Handle(DeleteMovieCommand request, CancellationToken cancellationToken) {
      return _moviesService.DeleteMovieById(request.Id);
    }
  }
}