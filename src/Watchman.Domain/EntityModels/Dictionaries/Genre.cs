using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Domain.EntityModels.Dictionaries {

  public class Genre : BaseEntity<int> {

    /// <summary>
    /// Name of movie genre
    /// </summary>
    [StringLength(30)]
    public string Name { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }

    public Genre() {
      Movies = new List<Movie>();
    }
  }
}