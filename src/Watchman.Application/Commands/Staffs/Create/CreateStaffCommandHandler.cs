using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Staffs.Create {

  public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, StaffReply> {
    private readonly IMovieService _moviesService;

    public CreateStaffCommandHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<StaffReply> Handle(CreateStaffCommand request, CancellationToken cancellationToken) {
      return await _moviesService.CreateStaff(request.Staff);
    }
  }
}