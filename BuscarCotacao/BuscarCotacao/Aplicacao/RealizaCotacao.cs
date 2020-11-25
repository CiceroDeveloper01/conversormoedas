using BuscarCotacao.Entidades;
using BuscarCotacao.Interfaces;
using BuscarCotacao.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuscarCotacao.Aplicacao
{
    public class RealizaCotacao
    {
        private readonly IBuscaDadosMoedas _buscaDadosMoedas;
        private readonly IGerarCotacao _gerarCotacao;
        private List<DataMoedasCotacoesCSV> moedasDataCotacoesCSV = new List<DataMoedasCotacoesCSV>();
        private List<MoedasApi> moedasApi = new List<MoedasApi>();
        private List<ValorMoedasCotacoesCSV> moedasValorCotacoes = new List<ValorMoedasCotacoesCSV>();
        private List<DadosMoedasCotacoesCSV> moedasDadosCotacoes = new List<DadosMoedasCotacoesCSV>();

        public RealizaCotacao(IBuscaDadosMoedas buscaDadosMoedas, IGerarCotacao gerarCotacao)
        {
            _buscaDadosMoedas = buscaDadosMoedas;
            _gerarCotacao = gerarCotacao;
        }

        public void IniciarProcessoCotacao()
        {
            BuscarDadosCotacoes();
            if (moedasDataCotacoesCSV != null
            && moedasApi != null
            && moedasValorCotacoes != null
            && moedasDadosCotacoes != null)
            {
                var cotacoesRealizadas = ObterCotacoes();
                _gerarCotacao.GerarArquivoCotacao(cotacoesRealizadas);
            }
        }

        private void BuscarDadosCotacoes()
        {
            Console.WriteLine("+++++ BUSCAR Cotações de Moedas");
            moedasDataCotacoesCSV = _buscaDadosMoedas.ObterDadosDataMoedasCotacoesCSV(Configuracoes.CaminhoCSVMoedasDataCotacoes);
            moedasApi = _buscaDadosMoedas.ObterDadosMoeadasApi(Configuracoes.UrlApi);
            moedasValorCotacoes = _buscaDadosMoedas.ObterDadosValorMoedasCotacoesCSV(Configuracoes.CaminhoCSVMoedasValorCotaoes);
            moedasDadosCotacoes = _buscaDadosMoedas.ObterDadosMoedasCotacoesCSV(Configuracoes.CaminhoCSVMoedasCotacoes);
            Console.WriteLine("+++++ FIM BUSCA Cotações de Moedas");
        }

        private IEnumerable<CotacoesRealizadas> ObterCotacoes()
        {
            Console.WriteLine("+++++ INICIO Consolidicação de Cotações de Moedas");
            var cotacoesRealizadas = from _moedasDataCotacoesCSV in moedasDataCotacoesCSV
                                     join _moedasapi in moedasApi
                                       on _moedasDataCotacoesCSV.Moeda
                                   equals _moedasapi.Moeda
                                     join _moedasDadosCotacoes in moedasDadosCotacoes
                                       on _moedasDataCotacoesCSV.Moeda
                                   equals _moedasDadosCotacoes.Moeda
                                     join _moedasValorCotacoes in moedasValorCotacoes
                                       on _moedasDadosCotacoes.Id_Cotacao
                                   equals _moedasValorCotacoes.Id_Cotacao
                                    where _moedasDataCotacoesCSV.DataRef >= _moedasapi.Data_Inicio
                                       && _moedasDataCotacoesCSV.DataRef <= _moedasapi.Data_Fim
                                    select
                                          new CotacoesRealizadas()
                                          {
                                              Moeda = _moedasDataCotacoesCSV.Moeda,
                                              DataCotacao = _moedasValorCotacoes.Dat_Cotacao,
                                              ValorCotacao = _moedasValorCotacoes.Vlr_Cotacao
                                          };
            Console.WriteLine("+++++ FIM Consolidicação de Cotações de Moedas");
            return cotacoesRealizadas;
        }
    }
}
