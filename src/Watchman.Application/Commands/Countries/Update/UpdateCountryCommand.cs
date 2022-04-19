using MediatR;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Countries.Update {

  public class UpdateCountryCommand : IRequest<CountryReply> {

    public UpdateCountryCommand(Country country) {
      Country = country;
    }

    public Country Country { get; }
  }
}