using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class StartUp
    {
        private readonly IConfiguration _config;
        public StartUp(IConfiguration config)
        {
            this._config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen( c =>{
                c.SwaggerDoc("v1", new OpenApiInfo{ Title = "TestWebApi" , Version = "v1" });
            });

            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlServer(this._config.GetConnectionString("LocalDataBase"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json","WebApi TestWebApi v1");
                });
            }

            app.UseAuthorization();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoint => 
            {
                endpoint.MapControllers();
            });

        }
    }

}
