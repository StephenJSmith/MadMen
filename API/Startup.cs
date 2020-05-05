using API.Extensions;
using API.Helpers;
using API.Middleware;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
  public class Startup
  {
    private readonly IConfiguration _config;
    
    public Startup(IConfiguration config)
    {
      _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAutoMapper(typeof(MappingProfiles));
      services.AddControllers();
      services.AddDbContext<MadMenContext>(x =>
          x.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
        
      services.AddDbContext<AppIdentityDbContext>(x => 
          x.UseSqlServer(_config.GetConnectionString("IdentityConnection")));
          
      services.AddApplicationService();
      services.AddIdentityServices(_config);
      services.AddSwaggerDocumentation();
      services.AddCors(option => {
        option.AddPolicy("CorsPolicy", policy => {
          policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins(_config["ClientUrl"]);
        });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseMiddleware<ExceptionMiddleware>();
      app.UseStatusCodePagesWithReExecute("/errors/{0}");

      app.UseHttpsRedirection();

      app.UseRouting();
      app.UseStaticFiles();

      app.UseCors("CorsPolicy");

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseSwaggerDocumentation();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
