using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Commands.Images.Delete {

  public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, ImageReply> {
    private readonly IMediasService _mediasService;

    public DeleteImageCommandHandler(IMediasService mediasService) {
      _mediasService = mediasService;
    }

    public async Task<ImageReply> Handle(DeleteImageCommand request, CancellationToken cancellationToken) {
      return await _mediasService.DeleteImage(request.Id);
    }
  }
}