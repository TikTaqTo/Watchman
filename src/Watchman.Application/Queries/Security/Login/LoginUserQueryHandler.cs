using MediatR;
using Watchman.Application.Abstractions;
using Watchman.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Watchman.Application.Queries.Security.Login {

  public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserManagerResponse> {
    private readonly ISecurityService _securityService;

    public LoginUserQueryHandler(ISecurityService securityService) {
      _securityService = securityService;
    }

    public async Task<UserManagerResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken) {
      return await _securityService.LoginAsync(request.Request);
    }
  }
}