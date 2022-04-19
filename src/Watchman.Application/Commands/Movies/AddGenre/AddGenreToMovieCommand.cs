using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.Replies;
using Watchman.Domain.Requests;

namespace Watchman.Application.Commands.Movies.AddGenre {

  public class AddGenreToMovieCommand : IRequest<MovieReply> {

    public AddGenreToMovieCommand(AddGenreToMovieRequest request) {
      Request = request;
    }

    public AddGenreToMovieRequest Request { get; }
  }
}