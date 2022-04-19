using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Countries {

  public class RetrieveAllCountriesQueryHandler : IRequestHandler<RetrieveAllCountriesQuery, CountriesReply> {
    private readonly IDictionariesService _dictionariesService;

    public RetrieveAllCountriesQueryHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<CountriesReply> Handle(RetrieveAllCountriesQuery request, CancellationToken cancellationToken) {
      return await _dictionariesService.RetrieveAllCountries();
    }
  }
}