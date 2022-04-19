using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Watchman.Domain.Requests {

  public class RegisterRequest {

    [Required]
    [StringLength(55)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 8)]
    public string Password { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 8)]
    public string ConfirmPassword { get; set; }

    public string Role { get; set; }
  }
}