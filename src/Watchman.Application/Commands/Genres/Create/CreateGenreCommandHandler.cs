using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Genres.Create {

  public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreReply> {
    private readonly IDictionariesService _dictionariesService;

    public CreateGenreCommandHandler(IDictionariesService dictionariesService) {
      _dictionariesService = dictionariesService;
    }

    public async Task<GenreReply> Handle(CreateGenreCommand request, CancellationToken cancellationToken) {
      return await _dictionariesService.CreateGenre(request.Genre);
    }
  }
}