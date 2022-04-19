using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Movies.AddStaff {

  public class AddStaffToMovieCommandHandler : IRequestHandler<AddStaffToMovieCommand, MovieReply> {
    private readonly IMovieService _moviesService;

    public AddStaffToMovieCommandHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MovieReply> Handle(AddStaffToMovieCommand request, CancellationToken cancellationToken) {
      return await _moviesService.AddStaffToMovie(request.Request);
    }
  }
}