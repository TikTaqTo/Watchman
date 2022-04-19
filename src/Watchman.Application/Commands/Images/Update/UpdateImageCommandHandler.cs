using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Images.Update {

  public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, ImageReply> {
    private readonly IMediasService _mediasService;

    public UpdateImageCommandHandler(IMediasService mediasService) {
      _mediasService = mediasService;
    }

    public async Task<ImageReply> Handle(UpdateImageCommand request, CancellationToken cancellationToken) {
      return await _mediasService.UpdateImage(request.Image);
    }
  }
}