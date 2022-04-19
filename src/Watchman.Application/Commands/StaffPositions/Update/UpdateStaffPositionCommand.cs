using MediatR;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.StaffPositions.Update
{
    public class UpdateStaffPositionCommand : IRequest<StaffPositionReply>
    {
        public UpdateStaffPositionCommand(StaffPosition staffPosition)
        {
            StaffPosition = staffPosition;
        }

        public StaffPosition StaffPosition { get; }
    }
}