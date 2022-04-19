using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Watchman.Api.Controllers.Dictionaries {

  [ApiController]
  [Route("api/dictionaries")]
  [Produces("application/json")]
  public partial class DictionariesController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    ///
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    public DictionariesController(IMediator mediator, IMapper mapper) {
      _mediator = mediator;
      _mapper = mapper;
    }
  }
}