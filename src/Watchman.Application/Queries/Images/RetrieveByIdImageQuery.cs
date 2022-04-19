using MediatR;
using System;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Images {

  public class RetrieveByIdImageQuery : IRequest<ImageReply> {

    public RetrieveByIdImageQuery(Guid id) {
      Id = id;
    }

    public Guid Id { get; }
  }
}