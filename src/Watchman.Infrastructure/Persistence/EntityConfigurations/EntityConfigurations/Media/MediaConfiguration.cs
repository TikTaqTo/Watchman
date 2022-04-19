using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchman.Domain.EntityModels.Media;

namespace Watchman.Infrastructure.Persistence.EntityConfigurations.EntityConfigurations.Media {

  public class MediaConfiguration : EntityBaseTypeConfiguration<Image, Guid> {

    protected override void ConfigureEntity(EntityTypeBuilder<Image> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(30)
          .IsRequired();
    }
  }
}