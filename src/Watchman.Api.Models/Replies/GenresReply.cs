using System.Collections.Generic;
using Watchman.Api.Models.Dictionaries;

namespace Watchman.Api.Models.Replies {

  public class GenresReply : CommonReply {
    public IEnumerable<Genre> Genres { get; set; }
  }
}