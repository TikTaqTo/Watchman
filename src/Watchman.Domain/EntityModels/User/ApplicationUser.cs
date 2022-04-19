using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchman.Domain.EntityModels.User {

  public class ApplicationUser : IdentityUser<Guid> {
  }
}