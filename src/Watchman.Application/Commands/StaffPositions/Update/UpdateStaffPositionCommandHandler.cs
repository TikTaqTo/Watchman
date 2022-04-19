using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.StaffPositions.Update
{
    public class UpdateStaffPositionCommandHandler : IRequestHandler<UpdateStaffPositionCommand, StaffPositionReply>
    {
        private readonly IDictionariesService _dictionariesService;

        public UpdateStaffPositionCommandHandler(IDictionariesService dictionariesService)
        {
            _dictionariesService = dictionariesService;
        }

        public async Task<StaffPositionReply> Handle(UpdateStaffPositionCommand request, CancellationToken cancellationToken)
        {
            return await _dictionariesService.UpdateStaffPosition(request.StaffPosition);
        }
    }
}