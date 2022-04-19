using MediatR;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Images {

  public class RetrieveImagesQuery : IRequest<ImagesReply> {

    public RetrieveImagesQuery(int top) {
      Top = top;
    }

    public int Top { get; }
  }
}