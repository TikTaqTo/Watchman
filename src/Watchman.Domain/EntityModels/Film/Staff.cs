using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Domain.EntityModels.Film {

  public class Staff : BaseEntity<Guid> {

    /// <summary>
    /// Name of a staff unit
    /// </summary>
    [StringLength(90)]
    public string Name { get; set; }

    /// <summary>
    /// Surname of a staff unit
    /// </summary>
    [StringLength(110)]
    public string Surname { get; set; }

    /// <summary>
    /// Date of birth of a staff unit
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Picture for a staff unit
    /// </summary>
    public Guid? ImageId { get; set; }

    public virtual ICollection<StaffPosition> StaffPositions { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }

    public Staff() {
      StaffPositions = new List<StaffPosition>();
      Movies = new List<Movie>();
    }
  }
}