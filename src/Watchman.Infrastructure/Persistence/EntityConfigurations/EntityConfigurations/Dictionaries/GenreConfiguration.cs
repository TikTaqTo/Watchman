using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Infrastructure.Persistence.EntityConfigurations.EntityConfigurations.Dictionaries {

  public class GenreConfiguration : EntityBaseTypeConfiguration<Genre, int> {

    protected override void ConfigureEntity(EntityTypeBuilder<Genre> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(50)
          .IsRequired();
      builder.HasMany(x => x.Movies)
        .WithMany(x => x.Genres);
    }
  }
}