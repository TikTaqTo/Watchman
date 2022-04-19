using MediatR;
using System;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMovieQueryPagination : IRequest<MoviesReply> {

    public RetrieveMovieQueryPagination(int page, int countElements) {
      Page = page;
      CountElements = countElements;
    }

    public int Page { get; }
    public int CountElements { get; }
  }
}