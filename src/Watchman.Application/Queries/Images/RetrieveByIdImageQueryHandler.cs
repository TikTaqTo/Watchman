using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Images {

  public class RetrieveByIdImageQueryHandler : IRequestHandler<RetrieveByIdImageQuery, ImageReply> {
    private readonly IMediasService _mediasService;

    public RetrieveByIdImageQueryHandler(IMediasService mediasService) {
      _mediasService = mediasService;
    }

    public async Task<ImageReply> Handle(RetrieveByIdImageQuery request, CancellationToken cancellationToken) {
      var imageReply = await _mediasService.RetrieveByIdImages(request.Id);
      return imageReply;
    }
  }
}