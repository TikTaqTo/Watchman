using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Movies {

  public class RetrieveMovieQueryById : IRequest<MovieReply> {

    public RetrieveMovieQueryById(Guid movieId) {
      MovieId = movieId;
    }

    public Guid MovieId { get; }
  }
}