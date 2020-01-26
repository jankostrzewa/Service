using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Service.API.Configuration;
using Service.Application.Queries;
using Service.Domain;
using Service.Infrastructure;
using System;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register strongly typed application configuration. This must be the first step.
            services.AddSingleton(resolver =>
            {
                services.Configure<AppConfiguration>(_ => Configuration.GetSection(nameof(AppConfiguration)));
                return resolver.GetRequiredService<IOptions<AppConfiguration>>().Value;
            });
                
            services.AddControllers();
            services.AddSwaggerApi();

            services.AddScoped<IRepository<WeatherForecast>, WeatherForecastRepository>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.Scan(s => s.FromAssembliesOf(typeof(IMediator), typeof(Startup), typeof(GetForecasts))
                .AddClasses(c => c.AssignableTo(typeof(IMediator))).AsImplementedInterfaces().WithScopedLifetime()
                .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>))).AsImplementedInterfaces().WithScopedLifetime());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(opt => {
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
