using BuscarCotacao.Aplicacao;
using BuscarCotacao.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuscarCotacao.Interfaces
{
    public interface IBuscaDadosMoedas
    {
        List<MoedasCSV> ObterDadosMoedaCSV(string pathFile);
        List<MoedasApi> ObterDadosMoeadaApi(string urlApi);
    }
}
