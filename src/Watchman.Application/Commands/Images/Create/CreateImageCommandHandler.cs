using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Images.Create {

  public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, ImageReply> {
    private readonly IMediasService _mediasService;

    public CreateImageCommandHandler(IMediasService mediasService) {
      _mediasService = mediasService;
    }

    public async Task<ImageReply> Handle(CreateImageCommand request, CancellationToken cancellationToken) {
      return await _mediasService.CreateImage(request.Image);
    }
  }
}