using Watchman.Domain.EntityModels.Film;

namespace Watchman.Domain.Replies {

  public class MovieReply : CommonReply {
    public Movie Movie { get; set; }
  }
}