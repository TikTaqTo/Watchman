using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Domain.Replies {

  public class StaffPositionReply : CommonReply {
    public StaffPosition StaffPosition { get; set; }
  }
}