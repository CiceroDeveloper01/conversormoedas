using System;
using System.IO;
using Conversor.Aplicacao.Handler;
using Conversor.Dominio.DTO.Entrada;
using Conversor.Dominio.DTO.Saida;
using Conversor.Dominio.Interface;
using Conversor.Entidades;
using Conversor.Repositorio;
using Conversor.Shared;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WebConversor
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            services.AddMvc();

            /*services.AddMvc().AddJsonOptions(opcoes =>
            {
                opcoes.JsonSerializerOptions.IgnoreNullValues = true;
                    
            });*/

            services.AddMvc().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });

            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson();


            Settings.ConnectionString = $"{Configuration["connectionString"]}";

            services.AddTransient<MoedaHandler, MoedaHandler>();
            services.AddTransient<IRepositorio<Moedas, SaidaMoeda>, MoedaRepositorio>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                  new OpenApiInfo { Title = "CONVERSOR MOEDAS", Version = "v1" });
            });

            services.AddResponseCompression();

            services.Configure<ElmahIoOptions>(Configuration.GetSection("ElmahIo"));
            services.AddElmahIo();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc();
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WinPro - V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseElmahIo();
        }
    }
}
