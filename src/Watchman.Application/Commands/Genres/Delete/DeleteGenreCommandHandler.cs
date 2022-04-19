using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Genres.Delete {

  public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, GenreReply> {
    private readonly IDictionariesService _dictionariesService;

    public DeleteGenreCommandHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<GenreReply> Handle(DeleteGenreCommand request, CancellationToken cancellationToken) {
      return await _dictionariesService.DeleteGenreById(request.Id);
    }
  }
}