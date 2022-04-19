using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Domain.EntityModels.Media {

  public class Image : BaseEntity<Guid> {

    /// <summary>
    /// Name of an image
    /// </summary>
    [StringLength(30)]
    public string Name { get; set; }

    /// <summary>
    /// Source of image in form of byte array
    /// </summary>
    [Column(TypeName = "image")]
    public byte[] Source { get; set; }

    /// <summary>
    /// Foreign key to a film
    /// </summary>
    public Guid? MovieId { get; set; }

    [ForeignKey(nameof(MovieId))]
    public virtual Movie Movie { get; set; }
  }
}