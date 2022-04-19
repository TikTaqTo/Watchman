using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Genres.Delete {

  public class DeleteGenreCommand : IRequest<GenreReply> {

    public DeleteGenreCommand(int id) {
      Id = id;
    }

    public int Id { get; set; }
  }
}