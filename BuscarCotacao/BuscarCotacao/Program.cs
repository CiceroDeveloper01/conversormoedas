using BuscarCotacao.Aplicacao;
using BuscarCotacao.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Timers;

namespace BuscarCotacao
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }
        private static Timer aTimer = new System.Timers.Timer();
        private static DateTime dataProximoProcessamento;
        private static string proximoProcessamento;
        static void Main(string[] args)
        {
            InicializarConfiguracoes();
            dataProximoProcessamento = DateTime.Now.AddSeconds(10);
            proximoProcessamento = dataProximoProcessamento.ToString("HH:mm:ss");
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
            Console.WriteLine("Pressione \'S\' para sair e fechar o processamento.");
            while (Console.Read() != 'E') ;
        }

        static void InicializarConfiguracoes()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            Configuracoes.UrlApi = $"{Configuration["urlApi"]}";
            Configuracoes.CaminhoCSVMoedasDataCotacoes = $"{Configuration["caminhoCSVMoedasDataCotacoes"]}";
            Configuracoes.CaminhoCSVGravacaoResultadoCotacoes = $"{Configuration["caminhoCSVGravacaoResultadoCotacoes"]}";
            Configuracoes.CaminhoCSVMoedasValorCotaoes = $"{Configuration["caminhoCSVMoedasValorCotaoes"]}";
            Configuracoes.CaminhoCSVMoedasCotacoes = $"{Configuration["caminhoCSVMoedasCotacoes"]}";
            Configuracoes.CaminhoLog = $"{Configuration["caminhoLog"]}";
            Configuracoes.NomePadraoArquivoLog = $"{Configuration["nomePadraoArquivoLog"]}";
        }

        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string exibirHorario = DateTime.Now.ToString("HH:mm:ss");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("+++++ ORQUESTRADOR DE Cotações de Moedas");
            Console.WriteLine("+++++ ");
            Console.WriteLine("+++++ Aguardando processamento ...");
            Console.WriteLine("+++++ Próximo Processamento: " + proximoProcessamento);
            Console.WriteLine("+++++ Timer: " + exibirHorario);
            if (proximoProcessamento == exibirHorario)
            {
                aTimer.Enabled = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+++++ ORQUESTRADOR DE Cotações de Moedas");
                Console.WriteLine("+++++ ");
                Console.WriteLine("+++++ Inicio Processo Cotação");
                Console.WriteLine("+++++ Hora Inicio: " + DateTime.Now.ToString("HH:mm:ss"));
                Console.Clear();
                Log.WriterLog($"+++++ Inicio de Processamento de Cotação as {proximoProcessamento}");
                var realizarCotacao = new RealizaCotacao(new BuscaDadosCotacoes(), new GeraNovoCSV());
                realizarCotacao.IniciarProcessoCotacao();
                Log.WriterLog($"+++++ Fim de Processamento de Cotação as {DateTime.Now.ToString("HH:mm:ss")}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+++++ Cotação finalizada");
                Console.WriteLine("+++++ ");
                Console.WriteLine("+++++ ");
                dataProximoProcessamento = DateTime.Now.AddMinutes(2);
                proximoProcessamento = dataProximoProcessamento.ToString("HH:mm:ss");
                if (dataProximoProcessamento < DateTime.Now)
                {
                    dataProximoProcessamento = DateTime.Now.AddMinutes(2);
                    proximoProcessamento = dataProximoProcessamento.ToString("HH:mm:ss");
                }
                Console.WriteLine("+++++ Hora Fim: " + DateTime.Now);
                Console.WriteLine("+++++ ");
                Console.WriteLine("+++++ Fim Processo Cotação");
                Console.WriteLine("+++++ ");
                Console.WriteLine("+++++ Próxima Execução " + proximoProcessamento);
                aTimer.Enabled = true;
            }
            else
                if (dataProximoProcessamento < DateTime.Now)
                {
                    dataProximoProcessamento = DateTime.Now.AddMinutes(2);
                    proximoProcessamento = dataProximoProcessamento.ToString("HH:mm:ss");
                }
        }
    }
}
