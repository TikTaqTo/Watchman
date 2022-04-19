using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Countries {

  public class RetrieveCountriesQueryHandler : IRequestHandler<RetrieveCountriesQuery, CountriesReply> {
    private readonly IDictionariesService _dictionariesService;

    public RetrieveCountriesQueryHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<CountriesReply> Handle(RetrieveCountriesQuery request, CancellationToken cancellationToken) {
      var countriesReply = await _dictionariesService.RetrieveCountries(request.Top);
      return countriesReply;
    }
  }
}