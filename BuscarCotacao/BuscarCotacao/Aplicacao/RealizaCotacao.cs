using BuscarCotacao.Entidades;
using BuscarCotacao.Interfaces;
using BuscarCotacao.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BuscarCotacao.Aplicacao
{
    public class RealizaCotacao
    {
        private readonly IBuscaDadosMoedas _buscaDadosMoedas;
        public RealizaCotacao(IBuscaDadosMoedas buscaDadosMoedas)
        {
            _buscaDadosMoedas = buscaDadosMoedas;
        }

        public void IniciarProcessoCotacao()
        {
            var moedasCSV = _buscaDadosMoedas.ObterDadosMoedaCSV(Configuracoes.CaminhoCsvLeitura);
            var moedasApi = _buscaDadosMoedas.ObterDadosMoeadaApi(Configuracoes.UrlApi);

            var moedas = from moedascsv in moedasCSV
                         join moedasapi in moedasApi
                           on moedascsv.IdMoeda 
                       equals moedasapi.Moeda 

        }

    }
}
