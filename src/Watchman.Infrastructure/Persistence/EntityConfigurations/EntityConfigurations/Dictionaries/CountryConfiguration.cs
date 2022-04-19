using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Infrastructure.Persistence.EntityConfigurations.EntityConfigurations.Dictionaries {

  public class CountryConfiguration : EntityBaseTypeConfiguration<Country, int> {

    protected override void ConfigureEntity(EntityTypeBuilder<Country> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(50)
          .IsRequired();
    }
  }
}