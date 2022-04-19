using System.Collections.Generic;
using Watchman.Domain.EntityModels.Media;

namespace Watchman.Domain.Replies {

  public class ImagesReply : CommonReply {
    public IEnumerable<Image> Images { get; set; }
  }
}