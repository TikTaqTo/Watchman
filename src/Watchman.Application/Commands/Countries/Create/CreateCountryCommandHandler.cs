using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Countries.Create {

  public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryReply> {
    private readonly IDictionariesService _dictionariesService;

    public CreateCountryCommandHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<CountryReply> Handle(CreateCountryCommand request, CancellationToken cancellationToken) {
      return await _dictionariesService.CreateCountry(request.Country);
    }
  }
}