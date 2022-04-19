using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.EntityModels.Film;
using Watchman.Domain.EntityModels.Media;
using Watchman.Domain.EntityModels.User;

namespace Watchman.Infrastructure.Persistence {

  public class WatchmanServiceContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid> {

    public WatchmanServiceContext() {
    }

    public WatchmanServiceContext(DbContextOptions<WatchmanServiceContext> options) : base(options) {
    }

    #region Dictionaries

    public DbSet<Country> Countries { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<StaffPosition> StaffPositions { get; set; }

    #endregion Dictionaries

    #region Film

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Staff> Staffs { get; set; }

    #endregion Film

    #region Media

    public DbSet<Image> Images { get; set; }

    #endregion Media

    #region User

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    #endregion User

    //Default usin testing server, change connecting string

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
      if (!options.IsConfigured) {
        options.UseSqlServer("Data Source=DESKTOP-4M2HR8M;Initial Catalog=WatchmanTest;Integrated Security=True");
      }
      base.OnConfiguring(options);
    }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);
    }
  }
}