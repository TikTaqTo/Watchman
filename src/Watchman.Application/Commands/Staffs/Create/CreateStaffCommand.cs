using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Film;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Staffs.Create {

  public class CreateStaffCommand : IRequest<StaffReply> {

    public CreateStaffCommand(Staff staff) {
      Staff = staff;
    }

    public Staff Staff { get; set; }
  }
}