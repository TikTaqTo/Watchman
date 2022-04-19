using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Countries {

  public class RetrieveAllCountriesQuery : IRequest<CountriesReply> {
  }
}