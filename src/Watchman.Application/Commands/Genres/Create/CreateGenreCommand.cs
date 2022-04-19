using MediatR;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Genres {

  public class CreateGenreCommand : IRequest<GenreReply> {

    public CreateGenreCommand(Genre genre) {
      Genre = genre;
    }

    public Genre Genre { get; }
  }
}