using BuscarCotacao.Entidades;
using BuscarCotacao.Interfaces;
using BuscarCotacao.Shared;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuscarCotacao.Aplicacao
{
    public class BuscaDadosCotacoes : IBuscaDadosMoedas
    {
        public List<MoedasApi> ObterDadosMoeadasApi(string urlApi)
        {
            try
            {
                IRestClient _client;
                _client = new RestClient();
                var request = new RestRequest(urlApi, Method.GET);
                request.AddHeader("Accept", "application/json");
                var response = _client.Execute(request);
                var items = JsonConvert.DeserializeObject<List<MoedasApi>>(response.Content);
                return items;
            }
            catch(Exception ex)
            {
                Log.WriterLog("Busca Cotações", "ObterDadosMoeadasApi", ex.Message);
                return null;
            }
        }
        public List<DataMoedasCotacoesCSV> ObterDadosDataMoedasCotacoesCSV(string pathFile)
        {
            try
            {
                var list = File.ReadAllLines(pathFile)
                    .Select(a => a.Split(';'))
                    .Skip(1)
                    .Select(c => new DataMoedasCotacoesCSV()
                    {
                        Moeda= c[0],
                        DataRef = Convert.ToDateTime(c[1])
                    })
                    .ToList();
                return list;
            }
            catch(Exception ex)
            {
                Log.WriterLog("Busca Cotações", "ObterDadosDataMoedasCotacoesCSV", ex.Message);
                return null;
            }
        }          
        public List<DadosMoedasCotacoesCSV> ObterDadosMoedasCotacoesCSV(string pathFile)
        {
            try
            {
                var list = File.ReadAllLines(pathFile)
                    .Select(a => a.Split(';'))
                    .Skip(1)
                    .Select(c => new DadosMoedasCotacoesCSV()
                    {
                        Id_Cotacao = int.Parse(c[0]),
                        Moeda = c[1]
                    })
                    .ToList();
                return list;
            }
            catch (Exception ex)
            {
                Log.WriterLog("Busca Cotações", "ObterDadosMoedasCotacoesCSV", ex.Message);
                return null;
            }
        }
        public List<ValorMoedasCotacoesCSV> ObterDadosValorMoedasCotacoesCSV(string pathFile)
        {
            try
            {
                var list = File.ReadAllLines(pathFile)
                    .Select(a => a.Split(';'))
                    .Skip(1)
                    .Select(c => new ValorMoedasCotacoesCSV()
                    {
                        Vlr_Cotacao = decimal.Parse(c[0]),
                         Id_Cotacao = int.Parse(c[1]),
                        Dat_Cotacao = Convert.ToDateTime(c[2])
                    })
                    .ToList();
                return list;
            }
            catch (Exception ex)
            {
                Log.WriterLog("Busca Cotações", "ObterDadosValorMoedasCotacoesCSV", ex.Message);
                return null;
            }
        }
    }
}