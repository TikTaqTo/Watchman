using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Movies.Delete {

  public class DeleteMovieCommand : IRequest<MovieReply> {

    public DeleteMovieCommand(Guid id) {
      Id = id;
    }

    public Guid Id { get; }
  }
}