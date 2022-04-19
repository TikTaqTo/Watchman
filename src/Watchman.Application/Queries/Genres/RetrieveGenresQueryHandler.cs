using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Genres {

  public class RetrieveGenresQueryHandler : IRequestHandler<RetrieveGenresQuery, GenresReply> {
    private readonly IDictionariesService _dictionariesService;

    public RetrieveGenresQueryHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<GenresReply> Handle(RetrieveGenresQuery request, CancellationToken cancellationToken) {
      return await _dictionariesService.RetrieveGenres();
    }
  }
}