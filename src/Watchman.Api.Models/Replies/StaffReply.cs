using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Api.Models.Film;

namespace Watchman.Api.Models.Replies {

  public class StaffReply : CommonReply {
    public Staff Staff { get; set; }
  }
}