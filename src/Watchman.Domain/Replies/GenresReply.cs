using System.Collections.Generic;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Domain.Replies {

  public class GenresReply : CommonReply {
    public IEnumerable<Genre> Genres { get; set; }
  }
}