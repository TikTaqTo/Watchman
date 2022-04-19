using System.Collections.Generic;
using Watchman.Api.Models.Film;

namespace Watchman.Api.Models.Dictionaries {

  public class Genre : BaseEntity<int> {
    public string Name { get; set; }
  }
}