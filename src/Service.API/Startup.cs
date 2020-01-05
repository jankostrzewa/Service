using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.API.Configuration;
using System;
using System.Reflection;

namespace Service.Application
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
            var cfg = new AppConfiguration();
            Configuration.GetSection("App").Bind(cfg);
            // Register strongly typed application configuration. This must be the first step.
            services.AddSingleton(_ => cfg);
            services.AddControllers();
            services.AddSwaggerApi(cfg);
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            //    .AddClasses(c => c.AssignableTo(typeof(IRequest<>)))
            //    .AsImplementedInterfaces()
            //    .WithTransientLifetime());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            
            // API description should be accessible without authorization. If needed, move below UseAuth.
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{env.ApplicationName} API V1"));
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
