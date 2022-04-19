using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.StaffPositions.Delete
{
    public class DeleteStaffPositionCommand : IRequest<StaffPositionReply>
    {
        public DeleteStaffPositionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}