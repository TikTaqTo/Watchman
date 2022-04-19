using System.Collections.Generic;
using Watchman.Api.Models.Film;

namespace Watchman.Api.Models.Replies {

  public class MoviesReply : CommonReply {
    public IEnumerable<Movie> Movies { get; set; }
  }
}