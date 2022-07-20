using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLEducation.Lib;
using GLEducation.Lib.Data;
using GLEducation.Lib.Logging;
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
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GLEducation.API
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
            services.AddDbContext<LogDBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("GLEduLogDataDB"))
                );
            
            services.AddScoped<ISimpleCalculator,SimpleCalculator>();
            services.AddScoped<IDiagnosticLogger,DebugLogger>();
          
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "GLEducationCalculator.API",
                    Version = "V1",
                    Description = "An API to Perform Basic Calculations"
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "GLEducation Calculator Test.API");
                c.RoutePrefix = string.Empty; 
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}