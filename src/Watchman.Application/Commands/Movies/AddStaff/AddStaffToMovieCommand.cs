using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.Replies;
using Watchman.Domain.Requests;

namespace Watchman.Application.Commands.Movies.AddStaff {

  public class AddStaffToMovieCommand : IRequest<MovieReply> {

    public AddStaffToMovieCommand(AddStaffToMovieRequest request) {
      Request = request;
    }

    public AddStaffToMovieRequest Request { get; }
  }
}