using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.EntityModels.Media;

namespace Watchman.Domain.EntityModels.Film {

  public class Movie : BaseEntity<Guid> {

    /// <summary>
    /// Name of a movie
    /// </summary>
    [StringLength(190)]
    public string Name { get; set; }

    /// <summary>
    /// Description of a movie
    /// </summary>
    [StringLength(900)]
    public string Description { get; set; }

    /// <summary>
    /// Year when movie was released for audience
    /// </summary>
    [Range(1900, 3000)]
    public int YearOfIssue { get; set; }

    public int CountryId { get; set; }

    [ForeignKey(nameof(CountryId))]
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