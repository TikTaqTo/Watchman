using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Watchman.Api.Models.Dictionaries;

namespace Watchman.Api.Models.Film {

  public class Staff : BaseEntity<Guid> {
    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Guid? ImageId { get; set; }

    public virtual ICollection<StaffPosition> StaffPositions { get; set; }

    [JsonIgnore]
    public virtual ICollection<Movie> Movies { get; set; }

    public Staff() {
      StaffPositions = new List<StaffPosition>();
      Movies = new List<Movie>();
    }
  }
}