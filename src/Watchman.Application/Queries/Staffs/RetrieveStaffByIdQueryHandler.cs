using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Staffs {

  public class RetrieveStaffByIdQueryHandler : IRequestHandler<RetrieveStaffByIdQuery, StaffReply> {
    private readonly IMovieService _moviesService;

    public RetrieveStaffByIdQueryHandler(IMovieService moviesService) {
      _moviesService = moviesService;
    }

    public async Task<StaffReply> Handle(RetrieveStaffByIdQuery request, CancellationToken cancellationToken) {
      var staffReply = await _moviesService.RetrieveStaffById(request.StaffId);
      return staffReply;
    }
  }
}