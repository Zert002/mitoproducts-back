using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MitoProducts.DataAccess;
using MitoProducts.Services;
using MitoProductsApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitoProductsApi
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false, reloadOnChange: true);

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        private readonly string _corsConfiguration = "_corsConfiguration";
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddInjection();

            services.AddDbContext<MitoProductsDbContext>(options =>
            {
                //options.UseSqlServer(@"Server=localhost;Database=MitoProductsDb;Uid=sa;Pwd=Hecatombe@2019$;App=Api");
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
                // Solo para desarrollo
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddControllers(options =>
            {
                //options.Filters.Add<FiltroRecurso>();
                options.Filters.Add<MitoProductsFilterException>();
            });

            services
            .AddCors(options =>
                options.AddPolicy(_corsConfiguration,
                    builder =>
                    {
                        builder.WithOrigins("*", "http://localhost", "https://localhost");
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    }
                ))
            .AddMvcCore()
            .AddApiExplorer();

            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "MitoProductsApi",
                    Version = "v1",
                    Description = "API para Mitoproducts"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MitoProductsApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(_corsConfiguration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
