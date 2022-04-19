using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Watchman.Api.Controllers.Movies {

  [ApiController]
  [Route("api/movies")]
  [Produces("application/json")]
  public partial class MoviesController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    ///
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    public MoviesController(IMediator mediator, IMapper mapper) {
      _mediator = mediator;
      _mapper = mapper;
    }
  }
}