using ContaBancaria.Core.Adapters;
using ContaBancaria.Core.Factories;
using ContaBancaria.Core.Interfaces.Adapters;
using ContaBancaria.Core.Interfaces.Factories;
using ContaBancaria.Core.Interfaces.Repositories;
using ContaBancaria.Core.Interfaces.Services;
using ContaBancaria.Core.Services;
using ContaBancaria.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PacoteBancaria.Core.Services;

namespace ContaBancaria
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Conta Bancária",
                    Description = "API para gerenciamento de Contas Bancárias",
                });
            });

            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IContaRepository, ContaRepository>();

            services.AddScoped<IExtratoService, ExtratoService>();
            services.AddScoped<IPacoteService, PacoteService>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            
            services.AddScoped<IContaFactory, ContaFactory>();
            services.AddScoped<IPacoteAdapter, PacoteAdapter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Test Version 1");
            });

            app.UseMvc();
        }
    }
}
