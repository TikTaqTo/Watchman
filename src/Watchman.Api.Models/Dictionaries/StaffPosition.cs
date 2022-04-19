using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Api.Models.Film;

namespace Watchman.Api.Models.Dictionaries {
  public class StaffPosition : BaseEntity<int> {
    public string Name { get; set; }
  }
}