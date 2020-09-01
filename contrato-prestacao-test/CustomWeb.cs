using contrato_prestacao_repository.Contrato;
using contrato_prestacao_repository.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_test
{
    public class CustomWeb<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddScoped<DataContext, DataContext>();
                services.AddTransient<ContratoRepository, ContratoRepository>();

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("DataBase");
                    options.UseInternalServiceProvider(serviceProvider);
                });
            });

        }
    }
}
