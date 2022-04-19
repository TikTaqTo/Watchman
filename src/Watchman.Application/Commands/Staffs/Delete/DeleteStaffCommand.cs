using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Staffs.Delete {

  public class DeleteStaffCommand : IRequest<StaffReply> {

    public DeleteStaffCommand(Guid id) {
      Id = id;
    }

    public Guid Id { get; }
  }
}