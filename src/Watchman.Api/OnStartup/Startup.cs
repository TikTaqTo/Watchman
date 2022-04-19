using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchman.Api.Filters;
using Watchman.Api.MappingProfiles;
using Watchman.Application;
using Watchman.Infrastructure;

namespace Watchman.Api.OnStartup {

  public class Startup {

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddControllers(x => x.Filters.Add<HttpGlobalExceptionFilter>());

      services.AddApplication(
        new[] {
          typeof(DictionariesProfile).Assembly,
          typeof(SecurityProfile).Assembly,
          typeof(MediasProfile).Assembly,
          typeof(MoviesProfile).Assembly,
        }
        );

      services.AddInfrastructure(Configuration)
        .AddDatabaseAuthorizationConfiguration(Configuration);

      services.AddSwagger();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseOpenApi();
        app.UseSwaggerUi3();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}