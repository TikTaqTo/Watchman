using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.StaffPositions.Delete
{
    public class DeleteStaffPositionCommandHandler : IRequestHandler<DeleteStaffPositionCommand, StaffPositionReply>
    {
        private readonly IDictionariesService _dictionariesService;

        public DeleteStaffPositionCommandHandler(IDictionariesService dictionariesService)
        {
            _dictionariesService = dictionariesService;
        }

        public async Task<StaffPositionReply> Handle(DeleteStaffPositionCommand request, CancellationToken cancellationToken)
        {
            return await _dictionariesService.DeleteStaffPositionById(request.Id);
        }
    }
}