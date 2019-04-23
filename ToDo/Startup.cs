using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ToDo.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

namespace ToDo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }
        
        /// <summary>
        /// Connects to Database, MVC, and Swagger
        /// </summary>
        /// <param name="services">Services Collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<ToDoDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ProductionConnection"]));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }
        
        /// <summary>
        /// Sets up display of swagger and direction to Exception page if there is an error
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">Hosting Environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

        }
    }
}
