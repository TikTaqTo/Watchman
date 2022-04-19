using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Domain.EntityModels.Dictionaries {

  public class StaffPosition : BaseEntity<int> {

    /// <summary>
    /// Name of StaffPosition: director, actor, producer and so on
    /// </summary>
    [StringLength(30)]
    public string Name { get; set; }

    public virtual ICollection<Staff> Staffs { get; set; }

    public StaffPosition() {
      Staffs = new List<Staff>();
    }
  }
}