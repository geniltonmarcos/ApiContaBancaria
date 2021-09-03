using ContaBancaria.Core.Interfaces.Repositories;
using ContaBancaria.Core.Interfaces.Services;
using ContaBancaria.Core.Services;
using ContaBancaria.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
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
