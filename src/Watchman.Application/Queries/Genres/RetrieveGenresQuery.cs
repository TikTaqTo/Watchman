using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Genres {

  public class RetrieveGenresQuery : IRequest<GenresReply> {
  }
}