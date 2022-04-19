using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchman.Domain.EntityModels.Film;

namespace Watchman.Infrastructure.Persistence.EntityConfigurations.EntityConfigurations.Film {

  public class StaffConfiguration : EntityBaseTypeConfiguration<Staff, Guid> {

    protected override void ConfigureEntity(EntityTypeBuilder<Staff> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(90)
          .IsRequired();
      builder.Property(x => x.Surname)
          .HasMaxLength(110)
          .IsRequired();
      builder.HasMany(x => x.Movies)
        .WithMany(x => x.Staffs);
      builder.HasMany(x => x.StaffPositions)
        .WithMany(x => x.Staffs);
    }
  }
}