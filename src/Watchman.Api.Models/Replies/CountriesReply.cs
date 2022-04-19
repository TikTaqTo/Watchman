using System.Collections.Generic;
using Watchman.Api.Models.Dictionaries;

namespace Watchman.Api.Models.Replies {

  public class CountriesReply : CommonReply {
    public IEnumerable<Country> Countries { get; set; }
  }
}