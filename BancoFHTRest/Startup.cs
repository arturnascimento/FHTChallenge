using BancoFHTRest.Data;
using BancoFHTRest.Interfaces;
using BancoFHTRest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace BancoFHTRest
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
            var APIInfo = new OpenApiInfo
            {
                Title = " API Banco Funcional Health Tech",
                Description = "Uma API criada para gerenciamento de contas bancárias.",
                Contact = new OpenApiContact
                {
                    Name = "Artur Nascimento",
                    Email = "artur.nascimento@outlook.com",
                    Url = new Uri("https://www.funcionalcorp.com.br/")
                },
                License = new OpenApiLicense
                {
                    Name = "Licença FHT",
                    Url = new Uri("https://www.funcionalcorp.com.br/")
                },
                Version = "v1"
            };
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", APIInfo);
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = $"{Path.Combine(AppContext.BaseDirectory, xmlFile)}";

                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<BancoFHTContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("BancoFHT"))
             );

            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<ContaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BancoFHTRest v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            //app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
