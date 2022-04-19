using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Staffs.Delete {

  public class DeleteStaffCommandHandler : IRequestHandler<DeleteStaffCommand, StaffReply> {
    private readonly IMovieService _moviesService;

    public DeleteStaffCommandHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<StaffReply> Handle(DeleteStaffCommand request, CancellationToken cancellationToken) {
      return await _moviesService.DeleteStaffById(request.Id);
    }
  }
}