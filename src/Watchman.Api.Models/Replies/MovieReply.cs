using Watchman.Api.Models.Film;

namespace Watchman.Api.Models.Replies {

  public class MovieReply : CommonReply {
    public Movie Movie { get; set; }
  }
}