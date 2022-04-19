using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Domain.Replies {

  public class StaffPositionsReply : CommonReply {
    public IEnumerable<StaffPosition> StaffPositions { get; set; }
  }
}