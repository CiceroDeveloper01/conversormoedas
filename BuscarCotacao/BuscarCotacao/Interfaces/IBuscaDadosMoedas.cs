using BuscarCotacao.Aplicacao;
using BuscarCotacao.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuscarCotacao.Interfaces
{
    public interface IBuscaDadosMoedas
    {
        List<DataMoedasCotacoesCSV> ObterDadosDataMoedasCotacoesCSV(string pathFile);
        List<MoedasApi> ObterDadosMoeadasApi(string urlApi);
        List<DadosMoedasCotacoesCSV> ObterDadosMoedasCotacoesCSV(string pathFile);
        List<ValorMoedasCotacoesCSV> ObterDadosValorMoedasCotacoesCSV(string pathFile);

    }
}
