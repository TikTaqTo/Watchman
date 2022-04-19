using MediatR;
using System;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Images {

  public class RetriveImageByMovieId : IRequest<ImageReply> {

    public RetriveImageByMovieId(Guid id) {
      Id = id;
    }

    public Guid Id { get; }
  }
}