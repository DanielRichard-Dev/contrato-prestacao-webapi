using System;
using contrato_prestacao_api.Data;
using contrato_prestacao_repository.Contrato;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace contrato_prestacao_api
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Contrato Prestação API",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Daniel Richard",
                            Url = new Uri("https://github.com/DanielRichard-Dev")
                        }
                    });
            });

            services.AddTransient<ContratoRepository,ContratoRepository>();

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));



            services.AddMemoryCache();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Contrato Prestação API");
            });
        }
    }
}
