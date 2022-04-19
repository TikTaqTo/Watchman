using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.StaffPositions.Create {

  public class CreateStaffPositionCommandHandler : IRequestHandler<CreateStaffPositionCommand, StaffPositionReply> {
    private readonly IDictionariesService _dictionariesService;

    public CreateStaffPositionCommandHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<StaffPositionReply> Handle(CreateStaffPositionCommand request, CancellationToken cancellationToken) {
      return await _dictionariesService.CreateStaffPosition(request.StaffPosition);
    }
  }
}