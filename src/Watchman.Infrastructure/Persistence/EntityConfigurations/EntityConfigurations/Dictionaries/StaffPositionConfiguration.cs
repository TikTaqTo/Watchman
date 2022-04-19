using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchman.Domain.EntityModels.Dictionaries;

namespace Watchman.Infrastructure.Persistence.EntityConfigurations.EntityConfigurations.Dictionaries {

  public class StaffPositionConfiguration : EntityBaseTypeConfiguration<StaffPosition, int> {

    protected override void ConfigureEntity(EntityTypeBuilder<StaffPosition> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(30)
          .IsRequired();
      builder.HasMany(x => x.Staffs)
        .WithMany(x => x.StaffPositions);
    }
  }
}