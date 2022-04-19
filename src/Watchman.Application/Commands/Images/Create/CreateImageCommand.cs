using MediatR;
using Watchman.Domain.EntityModels.Media;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Images.Create {

  public class CreateImageCommand : IRequest<ImageReply> {

    public CreateImageCommand(Image image) {
      Image = image;
    }

    public Image Image { get; }
  }
}