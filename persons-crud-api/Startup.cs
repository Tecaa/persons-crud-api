using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using persons_crud_api.Validators;

namespace persons_crud_api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<PersonContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PersonConnectionString"));
                options.EnableSensitiveDataLogging(_env.IsDevelopment());
            });

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyPolicy", policyOptions =>
                {
                    
                    policyOptions.WithOrigins(Configuration.GetValue<string>("FrontOrigin"));
                    policyOptions.AllowAnyMethod();
                    policyOptions.AllowAnyHeader();
                    policyOptions.WithExposedHeaders("Content-Disposition");
                });

                options.AddPolicy("LocalDevelopmentPolicy", policyOptions =>
                {
                    policyOptions.AllowAnyOrigin();
                    policyOptions.AllowAnyMethod();
                    policyOptions.AllowAnyHeader();
                    policyOptions.WithExposedHeaders("Content-Disposition");
                });
            });

            services.AddSingleton<RutValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("LocalDevelopmentPolicy");
            }
            else
            {
                app.UseCors("AllowAnyPolicy");
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
