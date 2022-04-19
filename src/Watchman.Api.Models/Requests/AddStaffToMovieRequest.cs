using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchman.Api.Models.Requests {

  public class AddStaffToMovieRequest {
    public Guid MovieId { get; set; }
    public Guid StaffId { get; set; }
  }
}