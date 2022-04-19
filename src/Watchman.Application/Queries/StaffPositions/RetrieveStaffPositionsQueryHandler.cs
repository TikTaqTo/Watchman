using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.StaffPositions {

  public class RetrieveStaffPositionsQueryHandler : IRequestHandler<RetrieveStaffPositionsQuery, StaffPositionsReply> {
    private readonly IDictionariesService _dictionariesService;

    public RetrieveStaffPositionsQueryHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<StaffPositionsReply> Handle(RetrieveStaffPositionsQuery request, CancellationToken cancellationToken) {
      var staffPositionsReply = await _dictionariesService.RetrieveStaffPositions();
      return staffPositionsReply;
    }
  }
}