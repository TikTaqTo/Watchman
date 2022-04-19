using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Genres.Update {

  public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreReply> {
    private readonly IDictionariesService _dictionariesService;

    public UpdateGenreCommandHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<GenreReply> Handle(UpdateGenreCommand request, CancellationToken cancellationToken) {
      return await _dictionariesService.UpdateGenre(request.Genre);
    }
  }
}