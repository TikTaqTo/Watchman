using MediatR;
using Watchman.Domain.Requests;
using Watchman.Domain.Responses;

namespace Watchman.Application.Commands.Security.Registration {

  public class RegisterUserCommand : IRequest<UserManagerResponse> {

    public RegisterUserCommand(RegisterRequest request) {
      Request = request;
    }

    public RegisterRequest Request { get; }
  }
}