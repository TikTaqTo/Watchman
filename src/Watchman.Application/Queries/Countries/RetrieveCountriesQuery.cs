using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Countries {

  public class RetrieveCountriesQuery : IRequest<CountriesReply> {

    public RetrieveCountriesQuery(int top) {
      Top = top;
    }

    public int Top { get; }
  }
}