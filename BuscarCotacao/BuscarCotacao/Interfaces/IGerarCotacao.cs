using BuscarCotacao.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuscarCotacao.Interfaces
{
    public interface IGerarCotacao
    {
        void GerarArquivoCotacao(IEnumerable<CotacoesRealizadas> cotacoesRealizadas);
    }
}
