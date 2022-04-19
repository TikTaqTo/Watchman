using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Watchman.Infrastructure.Persistence;
using Watchman.Domain.EntityModels.User;
using Watchman.Application.Abstractions;
using Watchman.Infrastructure.Services;

namespace Watchman.Infrastructure {

  public static class ServiceCollectionExtensions {

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration) {
      services.AddDbContext<WatchmanServiceContext>(options => {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            sqlOptions => {
              sqlOptions.MigrationsAssembly(typeof(ServiceCollectionExtensions).GetTypeInfo().Assembly
                          .GetName().Name);
              sqlOptions.EnableRetryOnFailure(
                          Convert.ToInt32(configuration.GetSection("InfrastructureSettings:MaxRetryCount").Value),
                          TimeSpan.FromSeconds(
                              Convert.ToInt32(configuration.GetSection("InfrastructureSettings:MaxDelayCount")
                                  .Value)),
                          null);
            });
      });

      services.AddHttpContextAccessor();

      services.AddScoped<IDictionariesService, DictionariesService>();
      services.AddScoped<ISecurityService, SecurityService>();
      services.AddScoped<IClaimService, ClaimService>();
      services.AddScoped<IMediasService, MediasService>();
      services.AddScoped<IMovieService, MovieService>();

      return services;
    }

    public static void AddDatabaseAuthorizationConfiguration(this IServiceCollection services,
            IConfiguration configuration) {
      services.AddIdentityCore<ApplicationUser>(options => {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequireNonAlphanumeric = true;
      })
          .AddRoles<IdentityRole<Guid>>()
          .AddEntityFrameworkStores<WatchmanServiceContext>()
          .AddDefaultTokenProviders();

      services.AddAuthentication(auth => {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidAudience = configuration["AuthSettings:Audience"],
          ValidIssuer = configuration["AuthSettings:Issuer"],
          RequireExpirationTime = true,
          IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"])),
          ValidateIssuerSigningKey = true
        };
      });
    }
  }
}