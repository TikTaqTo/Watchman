using MediatR;
using Watchman.Domain.EntityModels.Media;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Images.Update {

  public class UpdateImageCommand : IRequest<ImageReply> {

    public UpdateImageCommand(Image image) {
      Image = image;
    }

    public Image Image { get; }
  }
}