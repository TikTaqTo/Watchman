using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Staffs {

  public class RetrieveStaffByIdQuery : IRequest<StaffReply> {

    public RetrieveStaffByIdQuery(Guid staffId) {
      StaffId = staffId;
    }

    public Guid StaffId { get; }
  }
}