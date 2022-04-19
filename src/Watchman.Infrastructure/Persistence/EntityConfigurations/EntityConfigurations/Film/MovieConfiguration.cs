using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Infrastructure.Persistence.EntityConfigurations.EntityConfigurations.Film {

  public class MovieConfiguration : EntityBaseTypeConfiguration<Movie, Guid> {

    protected override void ConfigureEntity(EntityTypeBuilder<Movie> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(190)
          .IsRequired();

      builder.Property(x => x.Description)
          .HasMaxLength(900)
          .IsRequired();

      builder.HasMany(x => x.Images)
        .WithOne(x => x.Movie);

      builder.HasMany(x => x.Genres)
        .WithMany(x => x.Movies);

      builder.HasMany(x => x.Staffs)
        .WithMany(x => x.Movies);

      builder.HasOne(x => x.Country)
        .WithMany();
    }
  }
}