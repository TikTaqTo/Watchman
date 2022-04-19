using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchman.Api.Models.Requests;
using Watchman.Api.Models.Responses;
using Watchman.Application.Commands.Security.Registration;

namespace Watchman.Api.Controllers.Security {

  public partial class SecurityController {

    /// <summary>
    ///     Method to register
    /// </summary>
    /// <param name="register"></param>
    /// <returns></returns>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManagerResponse))]
    public async Task<IActionResult> Register([FromBody] RegisterRequest register) {
      var domainRequest = _mapper.Map<Domain.Requests.RegisterRequest>(register);
      var registerUserCommand = new RegisterUserCommand(domainRequest);
      var domainResponse = await _mediator.Send(registerUserCommand);
      var mappedResponse = _mapper.Map<UserManagerResponse>(domainResponse);
      return Ok(mappedResponse);
    }
  }
}