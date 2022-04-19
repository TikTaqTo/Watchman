using System.Collections.Generic;
using Watchman.Api.Models.Media;

namespace Watchman.Api.Models.Replies {

  public class ImagesReply : CommonReply {
    public IEnumerable<Image> Images { get; set; }
  }
}