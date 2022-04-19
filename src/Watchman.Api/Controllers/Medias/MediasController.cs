using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Watchman.Api.Controllers.Medias {

  [ApiController]
  [Route("api/medias")]
  [Produces("application/json")]
  public partial class MediasController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    ///
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    public MediasController(IMediator mediator, IMapper mapper) {
      _mediator = mediator;
      _mapper = mapper;
    }
  }
}