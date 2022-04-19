using MediatR;
using Watchman.Application.Abstractions;
using Watchman.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Watchman.Application.Commands.Security.Registration {

  public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserManagerResponse> {
    private readonly ISecurityService _securityService;

    public RegisterUserCommandHandler(ISecurityService securityService) {
      _securityService = securityService;
    }

    public async Task<UserManagerResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken) {
      return await _securityService.RegisterAsync(request.Request);
    }
  }
}