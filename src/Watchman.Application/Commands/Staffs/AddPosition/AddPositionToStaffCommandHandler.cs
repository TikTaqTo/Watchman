using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Staffs.AddPosition {

  public class AddPositionToStaffCommandHandler : IRequestHandler<AddPositionToStaffCommand, StaffReply> {
    private readonly IMovieService _moviesService;

    public AddPositionToStaffCommandHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<StaffReply> Handle(AddPositionToStaffCommand request, CancellationToken cancellationToken) {
      return await _moviesService.AddPositionToStaff(request.Request);
    }
  }
}