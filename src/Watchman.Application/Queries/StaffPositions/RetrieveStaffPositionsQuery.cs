using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.StaffPositions {

  public class RetrieveStaffPositionsQuery : IRequest<StaffPositionsReply> {
  }
}