using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.User;
using Watchman.Domain.Responses;

namespace Watchman.Application.Abstractions {

  public interface IClaimService {

    Task<UserManagerResponse> GetClaims(ApplicationUser user, params string[] roles);
  }
}