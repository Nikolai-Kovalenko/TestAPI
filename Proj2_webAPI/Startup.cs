using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.ConstrainedExecution;
using System;
using Nancy.Owin;

namespace Proj2_webAPI
{
    public class Startup 
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            string? credentials = _configuration.GetConnectionString("TestDatabase");
            Console.WriteLine(credentials);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddConsole(); // Добавляем консольный логгер
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Добавляем наше логгирование запросов как middleware
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseOwin(x => x.UseNancy());
        }
    }
}