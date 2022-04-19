using System;
using System.Collections.Generic;
using Watchman.Api.Models.Dictionaries;
using Watchman.Api.Models.Media;

namespace Watchman.Api.Models.Film {

  public class Movie : BaseEntity<Guid> {
    public string Name { get; set; }

    public string Description { get; set; }

    public int YearOfIssue { get; set; }

    public int CountryId { get; set; }
    public virtual Country Country { get; set; }

    public virtual ICollection<Genre> Genres { get; set; }

    public virtual ICollection<Staff> Staffs { get; set; }

    public virtual ICollection<Image> Images { get; set; }

    public Movie() {
      Genres = new List<Genre>();
      Staffs = new List<Staff>();
      Images = new List<Image>();
    }
  }
}