using BuscarCotacao.Entidades;
using BuscarCotacao.Interfaces;
using BuscarCotacao.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuscarCotacao.Aplicacao
{
    public class GeraNovoCSV : IGerarCotacao
    {
        public void GerarArquivoCotacao(IEnumerable<CotacoesRealizadas> cotacoesRealizadas)
        {
            Console.WriteLine("+++++ INICIO Geração de Arquivo de Cotações de Moedas");
            string nomeArquivo = $"{Configuracoes.NomePadraoArquivoLog}_{DateTime.Now.Date.ToString("yyyyMMdd")}_{DateTime.Now.ToString("HH:mm:ss")}.csv";
            string caminhoArquivo = $"{Configuracoes.CaminhoCSVGravacaoResultadoCotacoes}{nomeArquivo.Replace(":", "")}";
            using (StreamWriter writer = new StreamWriter($"{caminhoArquivo}", true))
            {
                writer.WriteLine("Moeda; DataCotacao; ValorCotacao");
                foreach (var cotacaoRealiazada in cotacoesRealizadas)
                {
                    Console.WriteLine($"+++++ Inserindo no Arquivo - Moeda: {cotacaoRealiazada.Moeda} Data de Cotação: {cotacaoRealiazada.DataCotacao.ToString("dd-MM-yyyy")} Valor de Cotação: {cotacaoRealiazada.ValorCotacao}");
                    writer.WriteLine($"{cotacaoRealiazada.Moeda}; {cotacaoRealiazada.DataCotacao.ToString("dd-MM-yyyy")}; {cotacaoRealiazada.ValorCotacao}");
                }
            }
            Console.WriteLine("+++++ FIM Geração de Arquivo de Cotações de Moedas");
        }
    }
}
