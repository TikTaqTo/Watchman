using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Staffs.Update {

  public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, StaffReply> {
    private readonly IMovieService _dictionariesService;

    public UpdateStaffCommandHandler(IMovieService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<StaffReply> Handle(UpdateStaffCommand request, CancellationToken cancellationToken) {
      return await _dictionariesService.UpdateStaff(request.Staff);
    }
  }
}