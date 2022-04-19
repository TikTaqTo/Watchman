using MediatR;
using Watchman.Domain.EntityModels.Film;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Staffs.Update {

  public class UpdateStaffCommand : IRequest<StaffReply> {

    public UpdateStaffCommand(Staff staff) {
      Staff = staff;
    }

    public Staff Staff { get; }
  }
}