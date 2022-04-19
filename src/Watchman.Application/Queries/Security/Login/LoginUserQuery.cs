using MediatR;
using Watchman.Domain.Requests;
using Watchman.Domain.Responses;

namespace Watchman.Application.Queries.Security.Login {

  public class LoginUserQuery : IRequest<UserManagerResponse> {

    public LoginUserQuery(LoginRequest request) {
      Request = request;
    }

    public LoginRequest Request { get; }
  }
}