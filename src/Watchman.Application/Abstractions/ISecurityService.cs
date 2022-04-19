using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.Requests;
using Watchman.Domain.Responses;

namespace Watchman.Application.Abstractions {

  public interface ISecurityService {

    Task<UserManagerResponse> RegisterAsync(RegisterRequest request);

    Task<UserManagerResponse> LoginAsync(LoginRequest request);
  }
}