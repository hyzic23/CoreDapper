using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coredapperapi.IRepository;
using coredapperapi.Repository;
using coredapperapi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace coredapperapi
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
            //services.AddControllersWithViews().AddFluentValidation();
            //services.AddControllers();
            // services.AddControllers()
            //     .AddFluentValidation(s => 
            //     {
            //         s.RegisterValidatorsFromAssemblyContaining<Startup>();
            //         s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            //     });

            services.AddControllers()
                .AddFluentValidation(s => 
                { 
                    s.RegisterValidatorsFromAssemblyContaining<Startup>(); 
                    s.RunDefaultMvcValidationAfterFluentValidationExecutes = false; 
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "coredapperapi", Version = "v1" });
            });

            services.AddTransient<IValidator, ProductValidator>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "coredapperapi v1"));
            }

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
