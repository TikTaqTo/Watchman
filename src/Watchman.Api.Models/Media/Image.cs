using System;
using Watchman.Api.Models.Film;

namespace Watchman.Api.Models.Media {

  public class Image : BaseEntity<Guid> {
    public string Name { get; set; }

    public byte[] Source { get; set; }

    public Guid? MovieId { get; set; }
  }
}