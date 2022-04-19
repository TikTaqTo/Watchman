using MediatR;
using System;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Images.Delete {

  public class DeleteImageCommand : IRequest<ImageReply> {

    public DeleteImageCommand(Guid id) {
      Id = id;
    }

    public Guid Id { get; }
  }
}