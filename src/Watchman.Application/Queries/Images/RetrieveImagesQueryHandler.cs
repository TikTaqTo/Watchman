using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.Replies;

namespace Watchman.Application.Queries.Images {

  public class RetrieveImagesQueryHandler : IRequestHandler<RetrieveImagesQuery, ImagesReply> {
    private readonly IMediasService _mediasService;

    public RetrieveImagesQueryHandler(IMediasService mediasService) {
      _mediasService = mediasService;
    }

    public async Task<ImagesReply> Handle(RetrieveImagesQuery request, CancellationToken cancellationToken) {
      var imagesReply = await _mediasService.RetrieveImages(request.Top);
      return imagesReply;
    }
  }
}