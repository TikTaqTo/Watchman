using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Domain.Replies {

  public class StaffReply : CommonReply {
    public Staff Staff { get; set; }
  }
}