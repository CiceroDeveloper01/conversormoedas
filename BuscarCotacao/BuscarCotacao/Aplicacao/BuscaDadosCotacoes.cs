using BuscarCotacao.Entidades;
using BuscarCotacao.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BuscarCotacao.Aplicacao
{
    public class BuscaDadosCotacoes : IBuscaDadosMoedas
    {
        public List<MoedasApi> ObterDadosMoeadaApi(string urlApi)
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
                return null;
            }
        }
        public List<MoedasCSV> ObterDadosMoedaCSV(string pathFile)
        {
            try
            {
                var list = File.ReadAllLines(pathFile)
                    .Select(a => a.Split(';'))
                    .Skip(1)
                    .Select(c => new MoedasCSV()
                    {
                        IdMoeda = c[0],
                        DataRef = Convert.ToDateTime(c[1])
                    })
                    .ToList();
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}