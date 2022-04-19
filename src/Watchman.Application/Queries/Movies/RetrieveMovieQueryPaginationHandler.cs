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

  public class RetrieveMovieQueryPaginationHandler : IRequestHandler<RetrieveMovieQueryPagination, MoviesReply> {
    private readonly IMovieService _moviesService;

    public RetrieveMovieQueryPaginationHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<MoviesReply> Handle(RetrieveMovieQueryPagination request, CancellationToken cancellationToken) {
      var moviesReply = await _moviesService.RetrieveMovieQueryPagination(request.Page, request.CountElements);
      return moviesReply;
    }
  }
}