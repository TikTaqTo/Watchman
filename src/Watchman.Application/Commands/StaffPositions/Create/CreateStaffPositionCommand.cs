using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.StaffPositions.Create {

  public class CreateStaffPositionCommand : IRequest<StaffPositionReply> {

    public CreateStaffPositionCommand(StaffPosition staffPosition) {
      StaffPosition = staffPosition;
    }

    public StaffPosition StaffPosition { get; }
  }
}