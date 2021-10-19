using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Service.API.Configuration;
using Service.Domain;
using Service.Infrastructure;
using System.Reflection;

namespace Service.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register strongly typed application configuration. This must be the first step.
            services.AddSingleton(resolver =>
            {
                services.Configure<AppConfiguration>(_ => Configuration.GetSection(nameof(AppConfiguration)));
                return resolver.GetRequiredService<IOptions<AppConfiguration>>().Value;
            });

            services.AddDbContext<WeatherForecastDbContext>(c => c.UseSqlite());

            services.AddControllers();
            services.AddSwaggerApi();
            services.AddAutoMapper(typeof(Application.MappingProfile));

            services.AddScoped<IRepository<WeatherForecast>, WeatherForecastRepository>();
            services.AddScoped<IReadOnlyRepository<WeatherForecast>, WeatherForecastRepository>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(Application.Commands.CreateNewWeatherForecastHandler).GetTypeInfo().Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
                opt.AllowAnyOrigin();
            });
            //app.UseHttpsRedirection();

            app.UseRouting();

            // API description should be accessible without authorization. If needed, move below UseAuth.
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{env.ApplicationName} API V1"));
            //app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
