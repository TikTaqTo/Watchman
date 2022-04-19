using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchman.Domain.Requests {

  public class AddGenreToMovieRequest {
    public Guid MovieId { get; set; }
    public int GenreId { get; set; }
  }
}