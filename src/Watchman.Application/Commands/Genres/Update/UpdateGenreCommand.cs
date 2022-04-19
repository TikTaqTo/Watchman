using MediatR;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Genres.Update {

  public class UpdateGenreCommand : IRequest<GenreReply> {

    public UpdateGenreCommand(Genre genre) {
      Genre = genre;
    }

    public Genre Genre { get; }
  }
}