using BuscarCotacao.Aplicacao;
using BuscarCotacao.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BuscarCotacao
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            InicializarConfiguracoes();
            var realizarCotacao = new RealizaCotacao(new BuscaDadosCotacoes());
            realizarCotacao.IniciarProcessoCotacao();

        }

        static void InicializarConfiguracoes()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            Configuracoes.UrlApi = $"{Configuration["urlApi"]}";
            Configuracoes.CaminhoCsvLeitura = $"{Configuration["caminhoCSVLeitura"]}";
            Configuracoes.CaminhoCsvGravar = $"{Configuration["caminhoCSVGravacao"]}";
        }
    }
}
