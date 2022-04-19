using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Watchman.Domain.EntityModels.Dictionaries {

  public class Country : BaseEntity<int> {

    /// <summary>
    /// Name of a country
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; }
  }
}