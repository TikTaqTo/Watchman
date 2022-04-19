using System.Collections.Generic;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Domain.Replies {

  public class MoviesReply : CommonReply {
    public IEnumerable<Movie> Movies { get; set; }
  }
}