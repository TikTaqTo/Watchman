using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Api.Models.Dictionaries;

namespace Watchman.Api.Models.Replies {

  public class CountryReply : CommonReply {
    public Country Country { get; set; }
  }
}