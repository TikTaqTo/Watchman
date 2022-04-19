using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMovieQueryByIdHandler : IRequestHandler<RetrieveMovieQueryById, MovieReply> {
    private readonly IMovieService _moviesService;

    public RetrieveMovieQueryByIdHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MovieReply> Handle(RetrieveMovieQueryById request, CancellationToken cancellationToken) {
      var moviesReply = await _moviesService.RetrieveMovieById(request.MovieId);
      return moviesReply;
    }
  }
}