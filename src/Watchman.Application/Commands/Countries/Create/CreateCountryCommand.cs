using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Countries.Create {

  public class CreateCountryCommand : IRequest<CountryReply> {

    public CreateCountryCommand(Country country) {
      Country = country;
    }

    public Country Country { get; }
  }
}