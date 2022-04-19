using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Countries.Update {

  public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, CountryReply> {
    private readonly IDictionariesService _dictionariesService;

    public UpdateCountryCommandHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<CountryReply> Handle(UpdateCountryCommand request, CancellationToken cancellationToken) {
      return await _dictionariesService.UpdateCountry(request.Country);
    }
  }
}