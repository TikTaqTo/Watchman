using System.Collections.Generic;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Domain.Replies {

  public class CountriesReply : CommonReply {
    public IEnumerable<Country> Countries { get; set; }
  }
}