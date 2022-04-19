using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.Replies;
using Watchman.Domain.Requests;

namespace Watchman.Application.Commands.Staffs.AddPosition {

  public class AddPositionToStaffCommand : IRequest<StaffReply> {

    public AddPositionToStaffCommand(AddPositionToStaffRequest request) {
      Request = request;
    }

    public AddPositionToStaffRequest Request { get; }
  }
}